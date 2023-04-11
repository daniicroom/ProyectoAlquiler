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
    [RoutePrefix("api/Vehiculo")]
    public class VehiculoController : ApiController
    {

        [HttpGet]
        [Route("GetAll")]
        public IQueryable<tblVehiculo> GetAll()
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.GetAll();
        }
        public IQueryable<viewComboVehiculo> Get()
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.LlenarComboVehiculo();
        }

        public tblVehiculo Get(string placa)
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.Consultar(placa);
        }
        public tblVehiculo GetByIdAlquiler(int idAlquiler)
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.GetByIdAlquiler(idAlquiler);
        }
        public string Post([FromBody] tblVehiculo vehiculo)
        {
            clsVehiculo oVehiculo = new clsVehiculo();
            oVehiculo.vehiculo = vehiculo;
            return oVehiculo.Grabarvehiculo();
        }
        public string Put([FromBody] tblVehiculo vehiculo)
        {
            clsVehiculo oVehiculo = new clsVehiculo();
            oVehiculo.vehiculo = vehiculo;
            return oVehiculo.Actualizar();
        }
        public string Delete([FromBody] tblVehiculo vehiculo)
        {
            clsVehiculo oVehiculo = new clsVehiculo();
            return oVehiculo.Eliminar(vehiculo.Placa);
        }
    }
}