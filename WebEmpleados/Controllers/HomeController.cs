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
        public ActionResult Index()
        {
            using (var db = new EmpleadosEntities())
            {
                return View(db.Empleados.ToList());
            }          
        }

        public ActionResult Alta()
        {
            return View(new Empleados());
        }

        [HttpPost]
        public ActionResult Alta(Empleados model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new EmpleadosEntities())
                {
                    db.Empleados.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
    }
}