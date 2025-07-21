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

        [HttpGet]
        public ActionResult CrearJugador()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearJugador(int identificacion, string nombre)
        {
            Jugador jugador = new Jugador();
            jugador.Identificacion = identificacion;
            jugador.Nombre = nombre;
            jugador.Marcador = 0;
            jugador.PartidasPerdidas = 0;
            jugador.PartidasGanadas = 0;


            return View();
        }
    }
}