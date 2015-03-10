using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEmpleados.Models;

namespace WebEmpleados.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        private EmpleadosEntities db = new EmpleadosEntities();

        public ActionResult Index()
        {
            var db = new EmpleadosEntities();

            return View(db.Empleados.ToList());                 
        }

        public ActionResult Alta()
        {
            ViewBag.idCargo = new SelectList(db.Cargos, "id", "nombre");
            ViewBag.idCentros = new MultiSelectList(db.Centros, "id", "nombre");

            return View(new Empleados());
        }

        [HttpPost]
        public ActionResult Alta(Empleados model)
        {
            if (ModelState.IsValid)
            {
                    db.Empleados.Add(model);

                foreach (var idCentro in model.idCentros)
                {
                    var c = db.Centros.Find(idCentro);
                    model.Centros.Add(c);
                }

                    db.SaveChanges();

                    return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Buscar()
        {
            var bus = Request.Form["busqueda"];

            var db = new EmpleadosEntities();

            var al = db.Empleados.Where(o => o.Cargos.nombre.Contains(bus));
            return View(al);
        }

    }
}