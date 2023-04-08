using ServicioAlquiler.Class;
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
    public class AlquilerController : ApiController
    {
        public string Post([FromBody] tblAlquiler alquiler)
        {
            clsAlquiler oAlquiler = new clsAlquiler();
            oAlquiler.alquiler = alquiler;
            return oAlquiler.GrabarAlquiler();
        }
    }
}