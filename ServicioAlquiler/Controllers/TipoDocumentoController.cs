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
    public class TipoDocumentoController : ApiController
    {
        public List<tblTipoDocumento> Get()
        {
            clsTipoDocumento tipoDocumento = new clsTipoDocumento();

            return tipoDocumento.GetAll();
        }
    }
}