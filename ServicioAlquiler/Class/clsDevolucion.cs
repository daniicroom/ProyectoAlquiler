using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquiler.Class
{
    public class clsDevolucion
    {
        private DBAlquilerVehiculoEntities5 dbAlquiler = new DBAlquilerVehiculoEntities5();
        public tblDevolucion devolucion { get; set; }

        public List<tblDevolucion> GetAll()
        {
            try
            {
                return dbAlquiler.tblDevolucions.OrderBy(x => x.Codigo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // SE OBTIENE EL ULTIMO CÓDIGO DE DEVOLUCIÓN REGISTRADO EN LA BASE DE DATOS
        private int ConsultarCodigoDevolucion()
        {
            return dbAlquiler.tblDevolucions.Select(p => p.Codigo).DefaultIfEmpty(0).Max();
        }


        //SE ACTUALIZA EL ESTADO DEL VEHICULO UNA VEZ EL CLIENTE LO DEVUELVE
        private void UpdateEstadoVehiculo(string placa)
        {
            try
            {
                tblVehiculo vehiculo = dbAlquiler.tblVehiculoes.Where(x => x.Placa == placa).FirstOrDefault();
                vehiculo.Estado = "DISPONIBLE";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //SE ACTUALIZA EL ESTADO DEL ALQUILER UNA VEZ EL CLIENTE DEVUELVE EL VEHICULO
        private void UpdateEstadoAlquiler()
        {
            try
            {
                tblAlquiler alquiler = ConsultarAlquiler();

                UpdateEstadoVehiculo(alquiler.PlacaVehiculo);

                dbAlquiler.SaveChanges();
                alquiler.EstadoAlquiler = "FINALIZADO";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // SE OBTIENEN LOS DATOS DE LA TABLA ALQUILER PARA CALCULAR EL TOTAL A PAGAR
        public IQueryable<viewDatosAlquiler> GetDatosAlquiler(int idAlquiler)
        {
            return from ve in dbAlquiler.Set<tblVehiculo>()
                   join al in dbAlquiler.Set<tblAlquiler>()
                   on ve.Placa equals al.PlacaVehiculo
                   where al.Codigo == idAlquiler
                   select new viewDatosAlquiler
                   {
                       CodigoAlquiler = al.Codigo,
                       Precio = ve.Precio,
                       FechaInicial = al.FechaInicio
                   };

        }




        //CRUD

        private tblAlquiler ConsultarAlquiler()
        {
            return dbAlquiler.tblAlquilers.Where(p => p.Codigo == devolucion.CodigoAlquiler).FirstOrDefault();
        }

        public string GrabarDevolucion()
        {
            IQueryable<tblDevolucion> devoluciones = dbAlquiler.tblDevolucions.Where(x => x.CodigoAlquiler == devolucion.CodigoAlquiler);
            if (devoluciones.Count() != 0)
            {
                return "NO SE PUEDE REGISTRAR OTRA DEVOLUCIÓN A ESTE ALQUILER";
            }
            //Consultar el número de factura
            devolucion.Codigo = ConsultarCodigoDevolucion() + 1;
            UpdateEstadoAlquiler();
            dbAlquiler.tblDevolucions.Add(devolucion);
            dbAlquiler.SaveChanges();
            return "SE REGISTRÓ LA DEVOLUCIÓN CON EL N°: " + devolucion.Codigo.ToString();
        }


        public tblDevolucion GetDevolucionByAlquiler(int idAlquiler)
        {
            return dbAlquiler.tblDevolucions
                       .Where(p => p.CodigoAlquiler == idAlquiler)
                       .FirstOrDefault();
        }

        public string Actualizar()
        {
            tblDevolucion _devolucion = dbAlquiler.tblDevolucions
                        .Where(p => p.Codigo == devolucion.Codigo)
                        .FirstOrDefault();

            _devolucion.CodigoAlquiler = devolucion.CodigoAlquiler;
            _devolucion.IDEmpleadoRecibe = devolucion.IDEmpleadoRecibe;
            _devolucion.FechaDevolucion = devolucion.FechaDevolucion;
            _devolucion.TotalPagar = devolucion.TotalPagar;

            dbAlquiler.SaveChanges();
            return "SE ACTUALIZÓ LA DEVOLUCIÓN";
        }

        public string Eliminar(int Codigo)
        {
            tblDevolucion devolucion = dbAlquiler.tblDevolucions
                        .Where(p => p.Codigo == Codigo)
                        .FirstOrDefault();

            dbAlquiler.tblDevolucions.Remove(devolucion);
            dbAlquiler.SaveChanges();
            return "SE ELIMINÓ LA DEVOLUCIÓN";
        }
    }
}