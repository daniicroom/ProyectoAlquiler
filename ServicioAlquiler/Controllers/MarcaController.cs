using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ServicioAlquiler.Class;
using ServicioAlquiler.Models;

namespace ServicioAlquiler.Controllers
{
    [EnableCors(origins: "http://localhost:54777", headers: "*", methods: "*")]
    public class MarcaController : ApiController
    {
        public List<viewCombo> Get()
        {
            clsMarca marca = new clsMarca();

            return marca.ListarMarcas();
        }

    }
}