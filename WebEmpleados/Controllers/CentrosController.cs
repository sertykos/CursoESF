using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEmpleados.Models;

namespace WebEmpleados.Controllers
{
    public class CentrosController : Controller
    {
        // GET: Centros
        EmpleadosEntities db = new EmpleadosEntities();

        public ActionResult Index()
        {
            return View(db.Centros);
        }

        // Cuando destruya el controlador cierra la conexion, Evitamos usar "using" daba problemas con el "lazy loading".
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }
    }
}