using Ahorcado_Grupo5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ahorcado_Grupo5.Controllers
{
    public class HomeController : Controller
    {
        private AhorcadoContext db = new AhorcadoContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MenuPrincipal()
        {
            return View();
        }

        // ESTE MÉTODO DEVUELVE LOS DETALLES DE UN JUGADOR COMO JSON
        public JsonResult GetJugadorDetails(int id)
        {
            var jugador = db.Jugadores.Find(id);

            if (jugador == null)
            {
                // Devuelve nulo si no se encuentra el jugador
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            var jugadorData = new
            {
                nombre = jugador.Nombre,
                marcador = jugador.Marcador,
                avatarUrl = jugador.AvatarUrl
            };

            // Devolvemos los datos y permitimos que se llame con GET desde el navegador
            return Json(jugadorData, JsonRequestBehavior.AllowGet);
        }

        // GET: CrearJugador
        public ActionResult CrearJugador()
        {
            return View();
        }

        // POST: CrearJugador

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearJugador([Bind(Include = "Identificacion,Nombre,AvatarUrl")] Jugador jugador)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Validar que la identificación sea única
                    if (db.Jugadores.Any(j => j.Identificacion == jugador.Identificacion))
                    {
                        ModelState.AddModelError("Identificacion", "Ya existe un jugador con esta identificación.");
                        return View(jugador);
                    }

                    // Validar que la identificación sea positiva
                    if (jugador.Identificacion <= 0)
                    {
                        ModelState.AddModelError("Identificacion", "La identificación debe ser un número entero positivo.");
                        return View(jugador);
                    }

                    // Validar que el nombre no esté vacío
                    if (string.IsNullOrWhiteSpace(jugador.Nombre))
                    {
                        ModelState.AddModelError("Nombre", "El nombre es obligatorio.");
                        return View(jugador);
                    }

                    // Validar longitud del nombre (máximo 50 caracteres)
                    if (jugador.Nombre.Length > 50)
                    {
                        ModelState.AddModelError("Nombre", "El nombre no puede exceder 50 caracteres.");
                        return View(jugador);
                    }

                    // Inicializar valores por defecto
                    jugador.Marcador = 0;
                    jugador.PartidasGanadas = 0;
                    jugador.PartidasPerdidas = 0;

                    // Guardar en la base de datos
                    db.Jugadores.Add(jugador);
                    db.SaveChanges();

                    // Redirigir al menú principal con mensaje de éxito
                    TempData["MensajeExito"] = $"¡Jugador '{jugador.Nombre}' creado exitosamente!";
                    return RedirectToAction("MenuPrincipal");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al crear el jugador. Por favor, inténtalo de nuevo.");
                // En un entorno de producción, deberías loggear el error
            }

            return View(jugador);
        }

        // GET: IniciarPartida
        public ActionResult IniciarPartida()
        {
            // Obtener lista de jugadores para seleccionar
            ViewBag.Jugadores = new SelectList(db.Jugadores, "Identificacion", "Nombre");
            return View();
        }

        // POST: IniciarPartida
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IniciarPartida(int jugadorId, string nivel)
        {
            try
            {
                var jugador = db.Jugadores.Find(jugadorId);
                if (jugador == null)
                {
                    TempData["MensajeError"] = "Jugador no encontrado.";
                    return RedirectToAction("IniciarPartida");
                }

                // Obtener una palabra aleatoria no usada
                var palabraAleatoria = db.Palabras
                    .Where(p => !p.HaSidoUsada)
                    .OrderBy(r => Guid.NewGuid())
                    .FirstOrDefault();

                if (palabraAleatoria == null)
                {
                    // Si no hay palabras disponibles, marcar todas como no usadas
                    var todasLasPalabras = db.Palabras.ToList();
                    foreach (var palabra in todasLasPalabras)
                    {
                        palabra.HaSidoUsada = false;
                    }
                    db.SaveChanges();

                    palabraAleatoria = db.Palabras
                        .OrderBy(r => Guid.NewGuid())
                        .FirstOrDefault();
                }

                if (palabraAleatoria == null)
                {
                    TempData["MensajeError"] = "No hay palabras disponibles para jugar.";
                    return RedirectToAction("IniciarPartida");
                }

                // Marcar la palabra como usada
                palabraAleatoria.HaSidoUsada = true;
                db.SaveChanges();

                // Crear nueva partida
                var partida = new Partida
                {
                    JugadorId = jugadorId,
                    PalabraId = palabraAleatoria.Id,
                    Nivel = nivel,
                    Fecha = DateTime.Now,
                    Victoria = false // Se actualizará al final de la partida
                };

                db.Partidas.Add(partida);
                db.SaveChanges();

                // Preparar datos para la vista de partida
                ViewBag.PalabraOculta = NormalizarPalabra(palabraAleatoria.TextoPalabra); // Normalizada para el juego
                ViewBag.PalabraOriginal = palabraAleatoria.TextoPalabra; // Original para mostrar al final
                ViewBag.Tiempo = ObtenerTiempoPorNivel(nivel);
                ViewBag.PartidaId = partida.Id;
                ViewBag.Jugador = jugador;
                ViewBag.Nivel = nivel;

                return View("Partida");
            }
            catch (Exception ex)
            {
                TempData["MensajeError"] = "Error al iniciar la partida. Por favor, inténtalo de nuevo.";
                return RedirectToAction("IniciarPartida");
            }
        }

        // GET: NuevaPartida (para el botón "Nueva Partida")
        public ActionResult NuevaPartida(int jugadorId, string nivel)
        {
            try
            {
                var jugador = db.Jugadores.Find(jugadorId);
                if (jugador == null)
                {
                    TempData["MensajeError"] = "Jugador no encontrado.";
                    return RedirectToAction("IniciarPartida");
                }

                // Obtener una palabra aleatoria no usada
                var palabraAleatoria = db.Palabras
                    .Where(p => !p.HaSidoUsada)
                    .OrderBy(r => Guid.NewGuid())
                    .FirstOrDefault();

                if (palabraAleatoria == null)
                {
                    // Si no hay palabras disponibles, marcar todas como no usadas
                    var todasLasPalabras = db.Palabras.ToList();
                    foreach (var palabra in todasLasPalabras)
                    {
                        palabra.HaSidoUsada = false;
                    }
                    db.SaveChanges();

                    palabraAleatoria = db.Palabras
                        .OrderBy(r => Guid.NewGuid())
                        .FirstOrDefault();
                }

                if (palabraAleatoria == null)
                {
                    TempData["MensajeError"] = "No hay palabras disponibles para jugar.";
                    return RedirectToAction("IniciarPartida");
                }

                // Marcar la palabra como usada
                palabraAleatoria.HaSidoUsada = true;
                db.SaveChanges();

                // Crear nueva partida
                var partida = new Partida
                {
                    JugadorId = jugadorId,
                    PalabraId = palabraAleatoria.Id,
                    Nivel = nivel,
                    Fecha = DateTime.Now,
                    Victoria = false // Se actualizará al final de la partida
                };

                db.Partidas.Add(partida);
                db.SaveChanges();

                // Preparar datos para la vista de partida
                ViewBag.PalabraOculta = NormalizarPalabra(palabraAleatoria.TextoPalabra); // Normalizada para el juego
                ViewBag.PalabraOriginal = palabraAleatoria.TextoPalabra; // Original para mostrar al final
                ViewBag.Tiempo = ObtenerTiempoPorNivel(nivel);
                ViewBag.PartidaId = partida.Id;
                ViewBag.Jugador = jugador;
                ViewBag.Nivel = nivel;

                return View("Partida");
            }
            catch (Exception ex)
            {
                TempData["MensajeError"] = "Error al iniciar la partida. Por favor, inténtalo de nuevo.";
                return RedirectToAction("IniciarPartida");
            }
        }



        public ActionResult Partida()
        {
            return View();
        }

        // Método para normalizar palabras (quitar tildes)
        private string NormalizarPalabra(string palabra)
        {
            if (string.IsNullOrEmpty(palabra))
                return palabra;

            // Diccionario de caracteres con tilde a sin tilde
            var normalizacion = new Dictionary<char, char>
            {
                {'á', 'a'}, {'é', 'e'}, {'í', 'i'}, {'ó', 'o'}, {'ú', 'u'},
                {'Á', 'A'}, {'É', 'E'}, {'Í', 'I'}, {'Ó', 'O'}, {'Ú', 'U'},
                {'ü', 'u'}, {'Ü', 'U'}, {'ñ', 'n'}, {'Ñ', 'N'}
            };

            string palabraNormalizada = palabra;
            foreach (var caracter in normalizacion)
            {
                palabraNormalizada = palabraNormalizada.Replace(caracter.Key, caracter.Value);
            }

            return palabraNormalizada;
        }

        // Método auxiliar para obtener tiempo según el nivel
        private int ObtenerTiempoPorNivel(string nivel)
        {
            switch (nivel?.ToLower())
            {
                case "fácil":
                case "facil":
                    return 90; // 1.5 minutos = 90 segundos
                case "normal":
                    return 60; // 1 minuto = 60 segundos
                case "difícil":
                case "dificil":
                    return 30; // 0.5 minutos = 30 segundos
                default:
                    return 60;
            }
        }

        // Método para actualizar puntuación del jugador
        [HttpPost]
        public JsonResult ActualizarPuntuacion(int jugadorId, bool victoria, string nivel)
        {
            try
            {
                var jugador = db.Jugadores.Find(jugadorId);
                if (jugador == null)
                {
                    return Json(new { success = false, message = "Jugador no encontrado" });
                }

                int puntos = CalcularPuntos(victoria, nivel);

                jugador.Marcador += puntos;
                if (victoria)
                {
                    jugador.PartidasGanadas++;
                }
                else
                {
                    jugador.PartidasPerdidas++;
                }

                db.SaveChanges();

                return Json(new { 
                    success = true, 
                    nuevoMarcador = jugador.Marcador,
                    partidasGanadas = jugador.PartidasGanadas,
                    partidasPerdidas = jugador.PartidasPerdidas
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al actualizar puntuación" });
            }
        }

        // Método para calcular puntos según el resultado y nivel
        private int CalcularPuntos(bool victoria, string nivel)
        {
            int puntosBase = 0;
            switch (nivel?.ToLower())
            {
                case "fácil":
                case "facil":
                    puntosBase = 1;
                    break;
                case "normal":
                    puntosBase = 2;
                    break;
                case "difícil":
                case "dificil":
                    puntosBase = 3;
                    break;
                default:
                    puntosBase = 1;
                    break;
            }

            return victoria ? puntosBase : -puntosBase;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Leaderboard()
        {
            var jugadores = db.Jugadores
                .OrderByDescending(j => j.Marcador)
                .ToList();
            return View(jugadores);
        }
    }
}