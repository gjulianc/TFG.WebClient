using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5_SeedProject.Controllers
{
    public class VehiculosController : Controller
    {
        // GET: Vehiculos
        public ActionResult Index()
        {
            ViewData["SubTitle"] = "Aplicacion para el Control de Combustible en Flotas de Vehículos";
            ViewData["Message"] = "Estas en VEHICULOS";
            return View();
        }
    }
}