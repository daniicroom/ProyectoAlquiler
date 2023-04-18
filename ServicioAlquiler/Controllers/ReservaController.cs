﻿using ServicioAlquiler.Class;
using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ServicioAlquiler.Controllers
{
    [EnableCors(origins: "http://localhost:54777", headers: "*", methods: "*")]
    public class ReservaController : ApiController
    {
        //Se obtiene todo de la tabla Reservar
        public List<tblReservar> GetAll()
        {
            clsReserva oReserva = new clsReserva();
            return oReserva.GetAll();
        }

        // CRUD
        /*public tblReservar Get(int Codigo)
        {
            clsReserva reserva = new clsReserva();
            return reserva.Consultar(Codigo);
        }*/

        // Devolver la lista de reservas de un cliente
        public List<tblReservar> Get(string CedulaCliente)
        {
            clsReserva reserva = new clsReserva();
            return reserva.ConsultarByCliente(CedulaCliente);
        }

        public string Post([FromBody] tblReservar reserva)
        {
            clsReserva oReserva = new clsReserva();
            oReserva.reserva = reserva;
            return oReserva.GrabarReserva();
        }

        public string Put([FromBody] tblReservar reserva)
        {
            clsReserva oReserva = new clsReserva();
            oReserva.reserva = reserva;
            return oReserva.Actualizar();
        }
        public string Delete([FromBody] tblReservar reserva)
        {
            clsReserva oReserva = new clsReserva();
            return oReserva.Eliminar(reserva.Codigo);
        }

    }
}