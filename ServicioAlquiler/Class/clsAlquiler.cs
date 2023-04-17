using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquiler.Class
{
    public class clsAlquiler
    {
        private DBAlquilerVehiculoEntities5 dbAlquiler = new DBAlquilerVehiculoEntities5();
        public tblAlquiler alquiler { get; set; }

      

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


        //CRUD
        public tblAlquiler Consultar(string Documento)
        {
            return dbAlquiler.tblAlquilers.Where(x => x.tblCliente.Documento == Documento)
                .FirstOrDefault();

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

        public string GrabarEmpleado()
        {
            dbAlquiler.tblAlquilers.Add(alquiler);
            dbAlquiler.SaveChanges();
            return "Se ingresó el registro de alquiler con código: " + alquiler.Codigo.ToString();
        }

        public string Actualizar()
        {
            tblAlquiler _alquiler = dbAlquiler.tblAlquilers
                        .Where(p => p.Codigo == alquiler.Codigo)
                        .FirstOrDefault();

            _alquiler.CedulaCliente = alquiler.CedulaCliente;
            _alquiler.IDEmpleado = alquiler.IDEmpleado;
            _alquiler.IDTipoVehiculo = alquiler.IDTipoVehiculo;
            _alquiler.PlacaVehiculo = alquiler.PlacaVehiculo;
            _alquiler.FechaInicio = alquiler.FechaInicio;
            _alquiler.FechaFin = alquiler.FechaFin;

            dbAlquiler.SaveChanges();
            return "Se actualizó el alquiler";
        }

        public string Eliminar(int Codigo)
        {
            tblAlquiler alquiler = dbAlquiler.tblAlquilers
                        .Where(p => p.Codigo == Codigo)
                        .FirstOrDefault();

            dbAlquiler.tblAlquilers.Remove(alquiler);
            dbAlquiler.SaveChanges();
            return "Se eliminó el alquiler";
        }
    }
}