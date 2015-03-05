using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEmpleados.Models
{
    public class BusquedaEmpleados
    {
        EmpleadosEntities db = new EmpleadosEntities();

        public List<Empleados> GetPorCargoLamda(string cargo)
        {
            var datos = db.Empleados.Where(o => o.apellidos == cargo);

            return datos.ToList();
        }
    }
}