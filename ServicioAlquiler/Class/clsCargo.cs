using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquiler.Class
{
    public class clsCargo
    {
        private DBAlquilerVehiculoEntities dbAlquiler = new DBAlquilerVehiculoEntities();
        public tblCargoEmpleado cargoEmpleado { get; set; }
        public List<tblCargoEmpleado> GetAll()
        {
            return dbAlquiler.tblCargoEmpleado.OrderBy(x => x.Nombre).ToList();
        }
    }
}