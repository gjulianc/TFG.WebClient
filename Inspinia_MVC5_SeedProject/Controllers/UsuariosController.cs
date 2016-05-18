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
    public class UsuariosController : Controller
    {
        private IRepositoryUsuarios usuarioRepository = new UsuarioMap();
        

        // GET: Usuarios
        public ActionResult Index()
        {
            ViewData["SubTitle"] = "Aplicacion para el Control de Combustible en Flotas de Vehículos";
            ViewData["Message"] = String.Format("Estas en USUARIOS");
            List<Usuario> usuarios = usuarioRepository.GetAllUsers();            
            return View(usuarios.ToList());
        }

        //GET: /Usuario/Detail/5
        public ActionResult Editar(int id)
        {
            Usuario u = new Usuario();
            u = usuarioRepository.GetUser(id);

            if (u == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(u);

        }
        
        [HttpPost] 
        public ActionResult Editar(int id, [Bind(Include ="Nombre, User, Password")] Usuario usuario)
        {
            Usuario u = new Usuario();
            u = usuarioRepository.GetUser(id);
            u.Nombre = usuario.Nombre;
            u.Password = usuario.Password;
            u.User = usuario.User;
            usuarioRepository.GuardarDatos();
            return RedirectToAction("Index");
        }  

        [HttpGet]
        public ActionResult Insertar()
        {
            var usuario = new Usuario();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Insertar(Usuario usuario)
        {
            usuarioRepository.InsertUser(usuario);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            Usuario u = new Usuario();
            u = usuarioRepository.GetUser(id);

            if (u == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(u);           
        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario u = new Usuario();
            u = usuarioRepository.GetUser(id);
            usuarioRepository.DeleteUser(u);
            return RedirectToAction("Index");
        }
    }
}