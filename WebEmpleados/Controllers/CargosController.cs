using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEmpleados.Models;

namespace WebEmpleados.Controllers
{
    public class CargosController : Controller
    {
        // GET: Cargos
        EmpleadosEntities db = new EmpleadosEntities();

        public ActionResult Cargos_Index()
        {
            return View(db.Cargos);
        }

        public ActionResult Add()
        {
            return View(new Cargos());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Cargos model)
        {
            if (ModelState.IsValid)
            {
                db.Cargos.Add(model);
                db.SaveChanges();
                return RedirectToAction("Cargos_Index");
            }

            return View(model);
        }

        public ActionResult Eliminar (int id)
        {
            var model = db.Cargos.Find(id);

            try
            {
                db.Cargos.Remove(model);
                db.SaveChanges();
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }

            return RedirectToAction("Cargos_Index");

        }

        public ActionResult Editar (int id)
        {
            var cargo = db.Cargos.Find(id);

            return View(cargo);
        }

        [HttpPost]
        public ActionResult Editar (Cargos model)
        {
            if (ModelState.IsValid)
            {
                var m = db.Cargos.Find(model.id);
                m.nombre = model.nombre;

                db.SaveChanges();

                return RedirectToAction("Cargos_Index");
            }

            return View(model);
        }






        // Cuando destruya el controlador cierra la conexion, Evitamos usar "using" daba problemas con el "lazy loading".
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }
    }
}