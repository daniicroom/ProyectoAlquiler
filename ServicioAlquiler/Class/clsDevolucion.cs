using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquiler.Class
{
    public class clsDevolucion
    {
        private DBAlquilerVehiculoEntities1 dbAlquiler = new DBAlquilerVehiculoEntities1();
        public tblDevolucion devolucion { get; set; }
        public string GrabarDevolucion()
        {
            //Consultar el número de factura
            devolucion.Codigo = ConsultarCodigoDevolucion() + 1;
            UpdateEstadoAlquiler();
            dbAlquiler.tblDevolucions.Add(devolucion);
            dbAlquiler.SaveChanges();
            return devolucion.Codigo.ToString();
        }
        private int ConsultarCodigoDevolucion()
        {
            return dbAlquiler.tblDevolucions.Select(p => p.Codigo).DefaultIfEmpty(0).Max();
        }


        private tblAlquiler ConsultarAlquiler()
        {
            return dbAlquiler.tblAlquilers.Where(p => p.Codigo == devolucion.CodigoAlquiler).FirstOrDefault();
        }
        private void UpdateEstadoAlquiler()
        {
            try
            {
                tblAlquiler alquiler = ConsultarAlquiler();

                UpdateEstadoVehiculo(alquiler.PlacaVehiculo);

                dbAlquiler.SaveChanges();
                alquiler.EstadoAlquiler = "Pagado";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void UpdateEstadoVehiculo(string placa)
        {
            try
            {
                tblVehiculo vehiculo = dbAlquiler.tblVehiculoes.Where(x => x.Placa == placa).FirstOrDefault();
                vehiculo.Estado = "Disponible";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
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
    }
}