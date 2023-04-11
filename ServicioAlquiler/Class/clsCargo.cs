using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquiler.Class
{
    public class clsCargo
    {
        private DBAlquilerVehiculoEntities1 dbAlquiler = new DBAlquilerVehiculoEntities1();
        public tblCargoEmpleado cargoEmpleado { get; set; }
        public List<tblCargoEmpleado> GetAll()
        {
            return dbAlquiler.tblCargoEmpleadoes.OrderBy(x => x.Nombre).ToList();
        }

    }
}