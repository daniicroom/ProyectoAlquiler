using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServicioAlquiler.Models;

namespace ServicioAlquiler.Class
{
    public class clsReserva
    {
        private DBAlquilerVehiculoEntities5 dbAlquiler = new DBAlquilerVehiculoEntities5();
        public tblReservar reserva { get; set; }
        public List<tblReservar> GetAll()
        {
            try
            {
                return dbAlquiler.tblReservars.OrderBy(x => x.Codigo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int ConsultarCodigoReserva()
        {
            return dbAlquiler.tblReservars.Select(p => p.Codigo).DefaultIfEmpty(0).Max();
        }

        // CRUDr
        public tblReservar Consultar(int Codigo)
        {
            return dbAlquiler.tblReservars.Where(x => x.Codigo == Codigo)
                .FirstOrDefault();

        }

        public string GrabarReserva()
        {
            try
            {
                //Consultar el número de factura
                reserva.Codigo = ConsultarCodigoReserva() + 1;
                UpdateEstadoVehiculo(reserva.PlacaVehiculo);
                reserva.EstadoReserva = "ACTIVO";
                dbAlquiler.tblReservars.Add(reserva);
                dbAlquiler.SaveChanges();
                return reserva.Codigo.ToString();
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

                vehiculo.Estado = "RESERVADO";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Actualizar()
        {
            tblReservar _reserva = dbAlquiler.tblReservars
                        .Where(p => p.Codigo == reserva.Codigo)
                        .FirstOrDefault();

            _reserva.CedulaCliente = reserva.CedulaCliente;
            _reserva.IDEmpleado = reserva.IDEmpleado;
            _reserva.IDTipoVehiculo = reserva.IDTipoVehiculo;
            _reserva.PlacaVehiculo = reserva.PlacaVehiculo;
            _reserva.EstadoReserva = reserva.EstadoReserva;
            _reserva.FechaInicio = reserva.FechaInicio;
            _reserva.FechaFin = reserva.FechaFin;

            dbAlquiler.SaveChanges();
            return "SE ACTUALIZÓ LA RESERVA";
        }

        public string Eliminar(int Codigo)
        {
            tblReservar alquiler = dbAlquiler.tblReservars
                        .Where(p => p.Codigo == Codigo)
                        .FirstOrDefault();

            dbAlquiler.tblReservars.Remove(reserva);
            dbAlquiler.SaveChanges();
            return "SE ELIMINÓ LA RESERVA";
        }
    }
}