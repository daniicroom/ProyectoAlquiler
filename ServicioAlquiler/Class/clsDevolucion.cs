using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquiler.Class
{
    public class clsDevolucion
    {
        private DBAlquilerVehiculoEntities dbAlquiler = new DBAlquilerVehiculoEntities();
        public tblDevolucion devolucion { get; set; }
        public string GrabarDevolucion()
        {
            try
            {
                //Consultar el número de factura
                devolucion.Codigo = ConsultarCodigoDevolucion() + 1;
                UpdateEstadoAlquiler();
                dbAlquiler.tblDevolucion.Add(devolucion);
                dbAlquiler.SaveChanges();
                return devolucion.Codigo.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private int ConsultarCodigoDevolucion()
        {
            return dbAlquiler.tblDevolucion.Select(p => p.Codigo).DefaultIfEmpty(0).Max();
        }


        private tblAlquiler ConsultarAlquiler()
        {
            return dbAlquiler.tblAlquiler.Where(p => p.Codigo == devolucion.CodigoAlquiler).FirstOrDefault();
        }
        private void UpdateEstadoAlquiler()
        {
            try
            {
                tblAlquiler alquiler = new tblAlquiler();
                alquiler = ConsultarAlquiler();

                UpdateEstadoVehiculo(alquiler.PlacaVehiculo);

                dbAlquiler.tblAlquiler.Remove(alquiler);
                alquiler.EstadoAlquiler = "Pagado";
                dbAlquiler.tblAlquiler.Add(alquiler);
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

                tblVehiculo vehiculo = dbAlquiler.tblVehiculo.Where(x => x.Placa == placa).FirstOrDefault();
                dbAlquiler.tblVehiculo.Remove(vehiculo);
                vehiculo.Estado = "Disponible";
                dbAlquiler.tblVehiculo.Add(vehiculo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}