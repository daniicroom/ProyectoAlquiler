using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServicioAlquiler.Class;
using ServicioAlquiler.Models;
using System.Web.Http.Cors;
namespace ServicioAlquiler.Controllers
{
    [EnableCors(origins: "http://localhost:54777", headers: "*", methods: "*")]
    public class ColorController : ApiController
    {
        public List<viewCombo> Get()
        {
            clsColor sede = new clsColor();

            return sede.ListarColorVehiculo();
        }

    }
}