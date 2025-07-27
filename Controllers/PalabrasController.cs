using System.Linq;
using System.Web.Mvc;
using Ahorcado_Grupo5.Models;
using System.Text;
using System.Globalization;

namespace Ahorcado_Grupo5.Controllers
{
    public class PalabrasController : Controller
    {
        // Conexión a la base de datos
        private AhorcadoContext db = new AhorcadoContext();

        // GET: Muestra el formulario para crear una palabra nueva
        public ActionResult Crear()
        {
            return View();
        }

        // POST: Procesa los datos del formulario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "Id,TextoPalabra,HaSidoUsada")] Palabra palabra)
        {
            if (ModelState.IsValid)
            {
                //Convertimos la palabra a mayúsculas para evitar errores
                palabra.TextoPalabra = palabra.TextoPalabra.ToUpper();

                //Validación de duplicados (sin distinguir mayúsculas/minúsculas ni tildes)
                var palabraNormalizada = NormalizarPalabra(palabra.TextoPalabra);

                // Obtenemos todas las palabras de la BD para comparar en memoria
                bool yaExiste = db.Palabras.ToList().Any(p => NormalizarPalabra(p.TextoPalabra) == palabraNormalizada);

                if (yaExiste)
                {
                    // Si ya existe, agregamos un error y volvemos a mostrar el formulario
                    ModelState.AddModelError("TextoPalabra", "La palabra ya existe en el diccionario.");
                    return View(palabra);
                }

                //Si todas las validaciones pasan, guardamos la palabra
                db.Palabras.Add(palabra);
                db.SaveChanges();

                // Mensaje de éxito y redirección
                TempData["SuccessMessage"] = "¡Palabra agregada exitosamente!";
                return RedirectToAction("Crear");
            }

            return View(palabra);
        }

        /// <summary>
        /// Helper para normalizar una palabra: la convierte a mayúsculas y le quita las tildes.
        /// </summary>
        private string NormalizarPalabra(string texto)
        {
            var normalizedString = texto.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC).ToUpper();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}