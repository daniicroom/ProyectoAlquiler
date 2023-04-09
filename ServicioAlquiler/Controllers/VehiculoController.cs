using ServicioAlquiler.Class;
using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace ServicioAlquiler.Controllers
{
    [EnableCors(origins: "http://localhost:54777", headers: "*", methods: "*")]
    public class VehiculoController : ApiController
    {
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
    }
}