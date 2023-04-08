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
    public class ClienteController : ApiController
    {
        [EnableCors(origins: "http://localhost:54777", headers: "*", methods: "*")]
        public tblCliente Get(string Documento)
        {
            clsCliente cliente = new clsCliente();
            return cliente.Consultar(Documento);
        }
    }
}