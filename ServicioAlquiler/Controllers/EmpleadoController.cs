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
    public class EmpleadoController : ApiController
    {
        /*public IQueryable<viewCombo> Get()
        {
            clsEmpleado empleado = new clsEmpleado();
            return empleado.LlenarComboEmpleados();
        }*/

        public tblEmpleado Get(string Documento)
        {
            clsEmpleado empleado = new clsEmpleado();
            return empleado.Consultar(Documento);
        }

        public string Post([FromBody] tblEmpleado empleado)
        {
            clsEmpleado oEmpleado = new clsEmpleado();
            oEmpleado.Empleado = empleado;
            return oEmpleado.GrabarEmpleado();
        }
        public string Put([FromBody] tblEmpleado empleado)
        {
            clsEmpleado oEmpleado = new clsEmpleado();
            oEmpleado.Empleado = empleado;
            return oEmpleado.Actualizar();
        }
        public string Delete([FromBody] tblEmpleado empleado)
        {
            clsEmpleado oEmpleado = new clsEmpleado();
            return oEmpleado.Eliminar(empleado.Documento);
        }
    }
}