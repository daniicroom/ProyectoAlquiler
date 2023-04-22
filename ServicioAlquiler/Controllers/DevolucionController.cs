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
    [RoutePrefix("api/Devolucion")]
    public class DevolucionController : ApiController
    {
        public string Post([FromBody] tblDevolucion devolucion)
        {
            clsDevolucion oDevolucion = new clsDevolucion();
            oDevolucion.devolucion = devolucion;
            return oDevolucion.GrabarDevolucion();
        }
        public viewDatosAlquiler GetDatosAlquiler(int idAlquiler)
        {
            clsDevolucion oDevolucion = new clsDevolucion();
            return oDevolucion.GetDatosAlquiler(idAlquiler).FirstOrDefault();
        }
        [HttpGet]
        [Route("GetDevolucionByAlquiler")]
        public tblDevolucion GetDevolucionByAlquiler(int idAlquiler)
        {
            clsDevolucion oDevolucion = new clsDevolucion();
            return oDevolucion.GetDevolucionByAlquiler(idAlquiler);
        }
        public string Put([FromBody] tblDevolucion devolucion)
        {
            clsDevolucion oDevolucion = new clsDevolucion();
            oDevolucion.devolucion = devolucion;
            return oDevolucion.Actualizar();
        }
        public string Delete([FromBody] tblDevolucion devolucion)
        {
            clsDevolucion oDevolucion = new clsDevolucion();
            return oDevolucion.Eliminar(devolucion.Codigo);
        }
        public List<tblDevolucion> GetAll()
        {
            clsDevolucion oDevolucion = new clsDevolucion();
            return oDevolucion.GetAll();
        }
    }
}