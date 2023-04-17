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
    public class ReservaController : ApiController
    {
        public List<tblReservar> GetAll()
        {
            clsReserva oReserva = new clsReserva();
            return oReserva.GetAll();
        }

    }
}