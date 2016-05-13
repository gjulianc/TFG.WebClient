using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TFG.WebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["SubTitle"] = "Bienvenido al Sistema de Control de Combustible  ";
            ViewData["Message"] = "Esto es el comiezo del Proyecto Fin de Grado de Gabriel Julián en UNIR.";

            return View();
        }

        public ActionResult Minor()
        {
            ViewData["SubTitle"] = "Simple example of second view";
            ViewData["Message"] = "Data are passing to view by ViewData from controller";

            return View();
        }
    }
}