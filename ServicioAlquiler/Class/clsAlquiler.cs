using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquiler.Class
{
    public class clsAlquiler
    {
        private DBAlquilerVehiculoEntities1 dbAlquiler = new DBAlquilerVehiculoEntities1();
        public tblAlquiler alquiler { get; set; }

        public tblAlquiler Consultar(string Documento)
        {
            return dbAlquiler.tblAlquilers.Where(x => x.tblCliente.Documento == Documento)
                .FirstOrDefault();
                    
        }


        public List<tblAlquiler> GetAll()
        {
            try
            {
                return dbAlquiler.tblAlquilers.OrderBy(x => x.Codigo).ToList();
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
                dbAlquiler.tblAlquilers.Add(alquiler);
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
            return dbAlquiler.tblAlquilers.Select(p => p.Codigo).DefaultIfEmpty(0).Max();
        }
        private void UpdateEstadoVehiculo(string placa)
        {
            try
            {
                tblVehiculo vehiculo = dbAlquiler.tblVehiculoes.Where(x => x.Placa == placa).FirstOrDefault();

                vehiculo.Estado = "EN ALQUILER";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}