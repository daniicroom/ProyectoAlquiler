using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquiler.Class
{
    public class clsAlquiler
    {
        private DBAlquilerVehiculoEntities dbAlquiler = new DBAlquilerVehiculoEntities();
        public tblAlquiler alquiler { get; set; }
        public List<tblAlquiler> GetAll()
        {
            try
            {
                return dbAlquiler.tblAlquiler.OrderBy(x => x.Codigo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GrabarAlquiler()
        {
            try
            {
                //Consultar el número de factura
                alquiler.Codigo = ConsultarCodigoAlquiler() + 1;
                UpdateEstadoVehiculo(alquiler.PlacaVehiculo);
                alquiler.EstadoAlquiler = "Activo";
                dbAlquiler.tblAlquiler.Add(alquiler);
                dbAlquiler.SaveChanges();
                return alquiler.Codigo.ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        private int ConsultarCodigoAlquiler()
        {
            return dbAlquiler.tblAlquiler.Select(p => p.Codigo).DefaultIfEmpty(0).Max();
        }
        private void UpdateEstadoVehiculo(string placa)
        {
            try
            {
                tblVehiculo vehiculo = dbAlquiler.tblVehiculo.Where(x => x.Placa == placa).FirstOrDefault();

                vehiculo.Estado = "En alquiler";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}