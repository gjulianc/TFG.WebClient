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
    public class VehiculosController : Controller
    {
        private IRepositoryVehiculos repository = new VehiculoMap();

        // GET: Vehiculos
        public ActionResult Index()
        {
            ViewData["SubTitle"] = "Aplicacion para el Control de Combustible en Flotas de Vehículos";
            ViewData["Message"] = "Estas en VEHICULOS";
            List<Vehiculo> vehiculos = repository.GetAllVehiculos();
            return View(vehiculos);
        }

        public ActionResult Editar(int id)
        {
            Vehiculo v = new Vehiculo();
            v = repository.GetVehiculo(id);

            if (v == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(v);

        }

        [HttpPost]
        public ActionResult Editar(int id, [Bind(Include = "Matricula, Marca, Modelo")] Vehiculo vehiculo)
        {
            Vehiculo v = new Vehiculo();
            v = repository.GetVehiculo(id);
            v.Marca = vehiculo.Marca;
            v.Modelo = vehiculo.Modelo;
            v.Matricula = vehiculo.Matricula;
            repository.GuardarDatos();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Insertar()
        {
            var vehiculo = new Vehiculo();
            return View(vehiculo);
        }

        [HttpPost]
        public ActionResult Insertar(Vehiculo vehiculo)
        {
            repository.InsertarVehiculo(vehiculo);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            Vehiculo v = new Vehiculo();
            v = repository.GetVehiculo(id);

            if (v == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(v);
        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehiculo v = new Vehiculo();
            v = repository.GetVehiculo(id);
            repository.DeleteVehiculo(v);
            return RedirectToAction("Index");
        }

    }
}