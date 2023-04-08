using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlquilerVehiculo.Controllers
{
    /// <summary>
    /// Descripción breve de ControladorEmpleado
    /// </summary>
    public class ControladorEmpleado : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hola a todos");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}