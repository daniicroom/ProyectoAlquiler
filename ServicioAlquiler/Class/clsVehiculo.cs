using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquiler.Class
{
    public class clsVehiculo
    {
        private DBAlquilerVehiculoEntities5 dbAlquiler = new DBAlquilerVehiculoEntities5();
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

   
        public IQueryable<viewDataTableVehiculos> LlenarTablaVehiculos()
        {
            return from veh in dbAlquiler.Set<tblVehiculo>()
                   join sede in dbAlquiler.Set<tblSede>() on veh.IDSede equals sede.Codigo
                   join marca in dbAlquiler.Set<tblMarca>() on veh.IDMarca equals marca.Codigo
                   join gama in dbAlquiler.Set<tblGama>() on veh.IDGama equals gama.Codigo
                   join color in dbAlquiler.Set<tblColor>() on veh.IDColor equals color.Codigo
                   join tipo in dbAlquiler.Set<tblTipoVehiculo>() on veh.IDTipoVehiculo equals tipo.Codigo

                   orderby veh.IDMarca
                   select new viewDataTableVehiculos
                   {
                       Placa = veh.Placa,
                       Descripcion = veh.Descripcion,
                       Estado = veh.Estado,
                       IDSede = veh.IDSede,
                       Sede = sede.Nombre,
                       IDMarca = veh.IDMarca,
                       Marca = marca.Nombre,
                       IDGama = veh.IDGama,
                       Gama = gama.Nombre,
                       IDColor = veh.IDColor,
                       Color = color.Nombre,
                       IDTipoVehiculo = veh.IDTipoVehiculo,
                       TipoVehiculo = tipo.Nombre,
                       Precio = veh.Precio

                   };

        }

        public List<tblVehiculo> ListarVehiculos(int Codigo)
        {
            return dbAlquiler.tblVehiculoes
                    .Where(x => x.IDTipoVehiculo == Codigo)
                    .OrderBy(x => x.Placa)
                    .ToList();
        }

        public List<viewComboVehiculo> LlenarComboVehiculosXTipo(int Codigo)
        {
            return dbAlquiler.tblVehiculoes
                    .Where(x => x.IDTipoVehiculo == Codigo && x.Estado == "DISPONIBLE")
                    .Select(p => new viewComboVehiculo
                    {
                        Codigo = p.Placa,
                        Nombre = p.tblMarca.Nombre + " " + p.Descripcion
                    }
                    )
                    .OrderBy(x => x.Nombre)
                    .ToList();

        }
        public List<viewComboVehiculo> LlenarAllComboVehiculosXTipo(int Codigo, string Placa)
        {
            return dbAlquiler.tblVehiculoes
                    .Where(x => x.IDTipoVehiculo == Codigo && (x.Estado == "DISPONIBLE" || x.Placa == Placa))
                    .Select(p => new viewComboVehiculo
                    {
                        Codigo = p.Placa,
                        Nombre = p.tblMarca.Nombre + " " + p.Descripcion
                    }
                    )
                    .OrderBy(x => x.Nombre)
                    .ToList();

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
        public string Deshabilitar(string Placa)
        {
            tblVehiculo _vehiculo = dbAlquiler.tblVehiculoes
                        .Where(p => p.Placa == Placa)
                        .FirstOrDefault();

            _vehiculo.Estado = "NO DISPONIBLE";
            dbAlquiler.SaveChanges();
            return "Se eliminó el vehiculo";
        }
    }
}