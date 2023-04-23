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

        public List<tblAlquiler> GetAll()
        {
            clsAlquiler oAlquiler = new clsAlquiler();
            return oAlquiler.GetAll();
        }


        public List<tblAlquiler> Get(string Documento)
        {
            clsAlquiler reserva = new clsAlquiler();
            return reserva.ConsultarByCliente(Documento);
        }

        public string Post([FromBody] tblAlquiler alquiler)
        {
            clsAlquiler oAlquiler = new clsAlquiler();
            oAlquiler.alquiler = alquiler;
            return oAlquiler.GrabarAlquiler();
        }

        
        public string Put([FromBody] tblAlquiler alquiler)
        {
            clsAlquiler oAlquiler = new clsAlquiler();
            oAlquiler.alquiler = alquiler;
            return oAlquiler.Actualizar();
        }
        public string Delete([FromBody] tblAlquiler alquiler)
        {
            clsAlquiler oAlquiler = new clsAlquiler();
            return oAlquiler.Eliminar(alquiler.Codigo);
        }
    }
}