using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquiler.Class
{
    public class clsEmpleado
    {
        private DBAlquilerVehiculoEntities dbAlquiler = new DBAlquilerVehiculoEntities();
        public tblEmpleado Empleado { get; set; }
        public tblEmpleado Consultar(string Documento)
        {
            return dbAlquiler.tblEmpleado
                    .Where(x => x.Documento == Documento)
                    .FirstOrDefault();
        }

    }
}