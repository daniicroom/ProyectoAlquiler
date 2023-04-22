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

        private string ultimaAccion;



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

        // ACTUALIZA EL ESTADO DEL VEHICULO EN LA TABLA DE VEHICULOS
        private void UpdateEstadoVehiculo(string placa, string estado)
        {
            try
            {
                tblVehiculo vehiculo = dbAlquiler.tblVehiculoes.Where(x => x.Placa == placa).FirstOrDefault();
                vehiculo.Estado = estado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
        // ACTUALIZA EL ESTADO DEL VEHICULO EN LA TABLA DE VEHICULOS
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
        */



        // CONSULTA EL ULTIMO CODIGO DE ALQUILER DE LA BASE DE DATOS Y LO INCREMENTA EN 1 PARA EL NUEVO CODIGO DE ALQUILER
        private int ConsultarCodigoAlquiler()
        {
            return dbAlquiler.tblAlquilers.Select(p => p.Codigo).DefaultIfEmpty(0).Max();
        }



        //CRUD
        public tblAlquiler Consultar(string Documento)
        {
            return dbAlquiler.tblAlquilers.Where(x => x.tblCliente.Documento == Documento)
                .FirstOrDefault();

        }

        //CONSULTA LA LSITA DE ALQUIRES ASOCIADOS AL DOCUMENTO DEL CLIENTE
        public List<tblAlquiler> ConsultarByCliente(string Documento)
        {
            return dbAlquiler.tblAlquilers.Where(x => x.CedulaCliente == Documento).ToList();

        }


        public string GrabarAlquiler()
        {
            try
            {
                //ultimaAccion = "GrabarAlquiler";

                //Consultar el número de factura
                alquiler.Codigo = ConsultarCodigoAlquiler() + 1;
                UpdateEstadoVehiculo(alquiler.PlacaVehiculo, "EN ALQUILER");
                alquiler.EstadoAlquiler = "ACTIVO";
                dbAlquiler.tblAlquilers.Add(alquiler);
                dbAlquiler.SaveChanges();

                return "SE REGISTRÓ EL ALQUILER CON CÓDIGO N°: " + alquiler.Codigo.ToString();


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
            if(_alquiler.PlacaVehiculo != alquiler.PlacaVehiculo)
            {
                UpdateEstadoVehiculo(_alquiler.PlacaVehiculo, "DISPONIBLE");
                UpdateEstadoVehiculo(alquiler.PlacaVehiculo, "EN ALQUILER");
            }
            _alquiler.CedulaCliente = alquiler.CedulaCliente;
            _alquiler.IDEmpleado = alquiler.IDEmpleado;
            _alquiler.IDTipoVehiculo = alquiler.IDTipoVehiculo;
            _alquiler.PlacaVehiculo = alquiler.PlacaVehiculo;
            _alquiler.FechaInicio = alquiler.FechaInicio;
            _alquiler.FechaFin = alquiler.FechaFin;

            dbAlquiler.SaveChanges();
            return "SE ACTUALIZÓ EL ALQUILER";
        }

        public string Eliminar(int Codigo)
        {
            //ultimaAccion = "EliminarAlquiler";

            tblAlquiler alquiler = dbAlquiler.tblAlquilers
                        .Where(p => p.Codigo == Codigo)
                        .FirstOrDefault();

            UpdateEstadoVehiculo(alquiler.PlacaVehiculo, "DISPONIBLE");

            dbAlquiler.tblAlquilers.Remove(alquiler);
            dbAlquiler.SaveChanges();

            return "SE ELIMINÓ EL ALQUILER";
        }
    }
}