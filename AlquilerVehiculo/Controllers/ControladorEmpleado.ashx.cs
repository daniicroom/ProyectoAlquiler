using AlquilerVehiculo.Class;
using AlquilerVehiculo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            string datosEmpleado;
            StreamReader reader = new StreamReader(context.Request.InputStream);//Captura la información que se envía desde el empleado (request)
            datosEmpleado = reader.ReadToEnd();//Lee los datos y los graba en el empleado
            //Convertir los datos del empleado, tipo json, a un objeto de tipo viewEmpleado
            viewEmpleado vEmpleado = JsonConvert.DeserializeObject<viewEmpleado>(datosEmpleado);

            context.Response.ContentType = "text/plain";
            context.Response.Write(Procesar(vEmpleado));
        }
        private string Procesar(viewEmpleado empleado)
        {
            clsEmpleado oEmpleado = new clsEmpleado();
            oEmpleado.vEmpleado = empleado;
            switch (empleado.Comando)
            {
                case "Insertar":
                    return oEmpleado.Insertar();
                case "Actualizar":
                    return oEmpleado.Actualizar();
                case "Eliminar":
                    return oEmpleado.Eliminar();
                case "Consultar":
                    return JsonConvert.SerializeObject(oEmpleado.Consultar(empleado.Documento));
                default:
                    return "Comando sin definir";
            }
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