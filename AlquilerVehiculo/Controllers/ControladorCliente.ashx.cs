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
    /// Descripción breve de ControladorCliente
    /// </summary>
    public class ControladorCliente : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string datosCliente;
            StreamReader reader = new StreamReader(context.Request.InputStream);//Captura la información que se envía desde el cliente (request)
            datosCliente = reader.ReadToEnd();//Lee los datos y los graba en el cliente
            //Convertir los datos del cliente, tipo json, a un objeto de tipo viewCliente
            viewCliente vcliente = JsonConvert.DeserializeObject<viewCliente>(datosCliente);

            context.Response.ContentType = "text/plain";
            context.Response.Write(Procesar(vcliente));
        }
        private string Procesar(viewCliente cliente)
        {
            clsCliente oCliente = new clsCliente();
            oCliente.vCliente = cliente;
            switch (cliente.Comando)
            {
                case "Insertar":
                    return oCliente.Insertar();
                case "Actualizar":
                    return oCliente.Actualizar();
                case "Eliminar":
                    return oCliente.Eliminar();
                case "Consultar":
                    return JsonConvert.SerializeObject(oCliente.Consultar(cliente.Documento));
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