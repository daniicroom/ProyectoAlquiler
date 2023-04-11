using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquiler.Class
{
    public class clsVehiculo
    {
        private DBAlquilerVehiculoEntities1 dbAlquiler = new DBAlquilerVehiculoEntities1();
        public tblVehiculo vehiculo { get; set; }
        public tblVehiculo Consultar(string placa)
        {
            return dbAlquiler.tblVehiculoes
                    .Where(x => x.Placa == placa)
                    .FirstOrDefault();
        }
        public IQueryable<tblVehiculo> GetAll()
        {
            return dbAlquiler.tblVehiculoes
                    .Where(x => x.Placa != "");
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
            return dbAlquiler.tblVehiculoes
                    .Where(x => x.tblAlquilers.FirstOrDefault().Codigo == idAlquiler)
                    .FirstOrDefault();
        }
        public string Grabarvehiculo()
        {
            dbAlquiler.tblVehiculoes.Add(vehiculo);
            dbAlquiler.SaveChanges();
            return "Se ingresó el vehiculo" + vehiculo.Placa.ToString();
        }
        public string Actualizar()
        {
            tblVehiculo _vehiculo = dbAlquiler.tblVehiculoes
                        .Where(p => p.Placa == vehiculo.Placa)
                        .FirstOrDefault();

            _vehiculo.Descripcion = vehiculo.Descripcion;
            _vehiculo.Estado = vehiculo.Estado;
            _vehiculo.IDSede = vehiculo.IDSede;
            _vehiculo.IDMarca = vehiculo.IDMarca;
            _vehiculo.IDGama = vehiculo.IDGama;
            _vehiculo.IDColor = vehiculo.IDColor;
            _vehiculo.Precio = vehiculo.Precio;
            _vehiculo.IDTipoVehiculo = vehiculo.IDTipoVehiculo;

            dbAlquiler.SaveChanges();
            return "Se actualizó el vehiculo";
        }
        public string Eliminar(string Placa)
        {
            tblVehiculo _vehiculo = dbAlquiler.tblVehiculoes
                        .Where(p => p.Placa == Placa)
                        .FirstOrDefault();

            dbAlquiler.tblVehiculoes.Remove(_vehiculo);
            dbAlquiler.SaveChanges();
            return "Se eliminó el vehiculo";
        }
    }
}