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
        public IQueryable<viewComboVehiculo> LlenarComboVehiculo()
        {
            return from ve in dbAlquiler.Set<tblVehiculo>()
                   join mar in dbAlquiler.Set<tblMarca>()
                   on ve.IDMarca equals mar.Codigo
                   orderby mar.Nombre + " " + ve.Descripcion
                   select new viewComboVehiculo
                   {
                       Codigo = ve.Placa,
                       Nombre = mar.Nombre + " - " + ve.Descripcion
                   };
        }
        public tblVehiculo GetByIdAlquiler(int idAlquiler)
        {
            return dbAlquiler.tblVehiculo
                    .Where(x => x.tblAlquiler.FirstOrDefault().Codigo == idAlquiler)
                    .FirstOrDefault();
        }
    }
}