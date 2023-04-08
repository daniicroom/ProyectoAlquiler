using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquiler.Class
{
    public class clsVehiculo
    {
        private DBAlquilerVehiculoEntities dbAlquiler = new DBAlquilerVehiculoEntities();
        public tblVehiculo vehiculo { get; set; }
        public tblVehiculo Consultar(string placa)
        {
            return dbAlquiler.tblVehiculo
                    .Where(x => x.Placa == placa)
                    .FirstOrDefault();
        }
    }
}