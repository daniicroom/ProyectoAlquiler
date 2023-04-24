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

        public IQueryable<tblVehiculo> GetAll()
        {
            return dbAlquiler.tblVehiculoes
                    .Where(x => x.Placa != "");
        }

        // DEVUELVE EL COMBO DE VEHICULOS EN LA FORMA: MARCA - NOMBRE DEL VEHICULO
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

        // LLENA EL DATATABLE DE VEHICULOS
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

        // DEVUELVE EL COMBO DE VEHICULOS CORRESPONDIENTES A UN TIPO Y QUE A DEMÁS ESTÁN EN ESTADO DISPONIBLE
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

        // DEVUELVE EL COMBO DE VEHICULOS DONDE EL ESTADO SEA DISPONIBLE, O QUE TENGA UNA RESERVA RELACIONADA AL DOCUMENTO DEL CLIENTE PARA LA RESERVA
        public List<viewComboVehiculo> LlenarComboVehiculosXTipoCliente(int Codigo, string Cedula)
        {
            return dbAlquiler.tblVehiculoes
                    .Where(x => x.IDTipoVehiculo == Codigo && (x.Estado == "DISPONIBLE" || (x.Estado == "RESERVADO" && x.tblReservars.Any(y => y.CedulaCliente == Cedula))))
                    .Select(p => new viewComboVehiculo
                    {
                        Codigo = p.Placa,
                        Nombre = p.tblMarca.Nombre + " " + p.Descripcion
                    }
                    )
                    .OrderBy(x => x.Nombre)
                    .ToList();
        }

        // DEVUELVE EL COMBO DE VEHICULOS CORRESPONDIENTES UN TIPO Y QUE A DEMÁS ESTÁN EN ESTADO DISPONIBLE O DONDE EL NÚMERO DE PLACA SEA IGUAL A LA REGISTRADA EN LA DB
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


        // CRUD
        public tblVehiculo Consultar(string placa)
        {
            return dbAlquiler.tblVehiculoes
                    .Where(x => x.Placa == placa)
                    .FirstOrDefault();
        }


        public string Grabarvehiculo()
        {
            dbAlquiler.tblVehiculoes.Add(vehiculo);
            dbAlquiler.SaveChanges();
            return "SE REGISTRÓ EL VEHÍCULO CON PLACA: " + vehiculo.Placa.ToString();
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
            return "SE ACTUALIZÓ LA INFORMACIÓN DEL VEHÍCULO";
        }

        public string Eliminar(string Placa)
        {
            tblVehiculo _vehiculo = dbAlquiler.tblVehiculoes
                        .Where(p => p.Placa == Placa)
                        .FirstOrDefault();

            dbAlquiler.tblVehiculoes.Remove(_vehiculo);
            dbAlquiler.SaveChanges();
            return "SE ELIMINÓ LA INFORMACIÓN DEL VEHÍCULO";
        }

        public string Deshabilitar(string Placa)
        {
            tblVehiculo _vehiculo = dbAlquiler.tblVehiculoes
                        .Where(p => p.Placa == Placa)
                        .FirstOrDefault();

            _vehiculo.Estado = "NO DISPONIBLE";
            dbAlquiler.SaveChanges();
            return "SE PUSO EL VEHÍCULO EN ESTADO NO DISPONIBLE";
        }
    }
}