using EFCore;
using EFData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TFG.Contrato;

namespace Inspinia_MVC5_SeedProject.Controllers
{
    public class BasesController : Controller
    {
        private IRepositoryBases repository = new BaseMap();

        // GET: Bases
        public ActionResult Index()
        {
            ViewData["SubTitle"] = "Aplicacion para el Control de Combustible en Flotas de Vehículos";
            ViewData["Message"] = "Estas en BASES";
            List<Base> bases = repository.GetAllBases();
            return View(bases);
        }

        public ActionResult Editar(int id)
        {
            Base b = new Base();
            b = repository.GetBase(id);

            if (b == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(b);
        }

        [HttpPost]
        public ActionResult Editar(int id, [Bind(Include = "Descripcion, Latitud, Longitud")] Base _base)
        {
            Base b = new Base();
            b = repository.GetBase(id);
            b.Descripcion = _base.Descripcion;
            b.Latitud = _base.Latitud;
            b.Longitud = _base.Longitud;
            repository.GuardarDatos();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Insertar()
        {
            var _base = new Base();
            return View(_base);
        }

        [HttpPost]
        public ActionResult Insertar(Base _base)
        {
            repository.InsertarBase(_base);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            Base b = new Base();
            b = repository.GetBase(id);

            if (b == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(b);
        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult DeleteConfirmed(int id)
        {
            Base b= new Base();
            b = repository.GetBase(id);
            repository.DeleteBase(b);
            return RedirectToAction("Index");
        }
    }
}