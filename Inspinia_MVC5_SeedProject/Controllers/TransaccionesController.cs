using EFCore;
using System.Collections.Generic;
using System.Web.Mvc;
using TFG.Contrato;
using EFData;

namespace Inspinia_MVC5_SeedProject.Controllers
{
    public class TransaccionesController : Controller
    {
        private IRepositoryTransacciones repository = new TransaccionMap();

        // GET: Transacciones
        public ActionResult Index()
        {
            ViewData["SubTitle"] = "Aplicacion para el Control de Combustible en Flotas de Vehículos";
            ViewData["Message"] = "Estas en TRANSACCIONES";
            List<Transaccion> transacciones = repository.GetAllTransacciones();
            return View(transacciones);
        }

        [HttpGet]
        public ActionResult Insertar()
        {
            var transaccion = new Transaccion();
            return View(transaccion);
        }

        [HttpPost]
        public ActionResult Insertar(Transaccion transaccion)
        {
            repository.InsertarTransaccion(transaccion);

            return RedirectToAction("Index");
        }
    }
}