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
    /// Descripción breve de ControladorVehiculo
    /// </summary>
    public class ControladorVehiculo : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string datosVehiculo;
            StreamReader reader = new StreamReader(context.Request.InputStream);//Captura la información que se envía desde el vehiculo (request)
            datosVehiculo = reader.ReadToEnd();//Lee los datos y los graba en el vehiculo
            //Convertir los datos del vehiculo, tipo json, a un objeto de tipo viewVehiculo
            viewVehiculo vVehiculo = JsonConvert.DeserializeObject<viewVehiculo>(datosVehiculo);

            context.Response.ContentType = "text/plain";
            context.Response.Write(Procesar(vVehiculo));
        }
        private string Procesar(viewVehiculo vehiculo)
        {
            clsVehiculo oVehiculo = new clsVehiculo();
            /*oVehiculo.vVehiculo = vehiculo;
            switch (vehiculo.Comando)
            {
                case "Insertar":
                    return oVehiculo.Insertar();
                case "Actualizar":
                    return oVehiculo.Actualizar();
                case "Eliminar":
                    return oVehiculo.Eliminar();
                case "Consultar":
                    return JsonConvert.SerializeObject(oVehiculo.Consultar(vehiculo.Placa));
                default:
                    return "Comando sin definir";
            }*/
            return "ok";
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