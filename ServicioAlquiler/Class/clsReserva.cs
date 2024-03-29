﻿using System;
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

        //SE ACTUALIZA EL ESTADO DEL VEHICULO EN LA TABLA DE VEHICULOS
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

        // SE CONSULTA EL ÚLTIMO CODIGO DE RESERVA REGISTRADO EN LA BASE DE DATOS
        private int ConsultarCodigoReserva()
        {
            return dbAlquiler.tblReservars.Select(p => p.Codigo).DefaultIfEmpty(0).Max();
        }


   
        // CRUD

        // DEVUELVE LA LISTA DE RESERVAS ASOCIADAS A UN CLIENTE
        public List<tblReservar> ConsultarByCliente(string CedulaCliente)
        {
            return dbAlquiler.tblReservars.Where(x => x.CedulaCliente == CedulaCliente).ToList();

        }

        public string GrabarReserva()
        {
            try
            {
                reserva.Codigo = ConsultarCodigoReserva() + 1;
                UpdateEstadoVehiculo(reserva.PlacaVehiculo, "RESERVADO");
                reserva.EstadoReserva = "ACTIVO";
                dbAlquiler.tblReservars.Add(reserva);
                dbAlquiler.SaveChanges();
                return "SE REGISTRÓ LA RESERVA CON CODIGO N° : " + reserva.Codigo.ToString();
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

            if (_reserva.PlacaVehiculo != reserva.PlacaVehiculo)
            {
                UpdateEstadoVehiculo(_reserva.PlacaVehiculo, "DISPONIBLE");
                UpdateEstadoVehiculo(reserva.PlacaVehiculo, "RESERVADO");
            }


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
            tblReservar _reserva = dbAlquiler.tblReservars
                        .Where(p => p.Codigo == Codigo)
                        .FirstOrDefault();

            UpdateEstadoVehiculo(_reserva.PlacaVehiculo, "DISPONIBLE");
            dbAlquiler.tblReservars.Remove(_reserva);
            dbAlquiler.SaveChanges();
            return "SE ELIMINÓ LA RESERVA";
        }

        public string Cancelar(int Codigo)
        {
            tblReservar _reserva = dbAlquiler.tblReservars
                        .Where(p => p.Codigo == Codigo)
                        .FirstOrDefault();

            UpdateEstadoVehiculo(_reserva.PlacaVehiculo, "DISPONIBLE");
            _reserva.EstadoReserva = "CANCELADA";
            dbAlquiler.SaveChanges();
            return "SE CANCELÓ LA RESERVA";
        }
    }
}