using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAlquiler.Models;
using Newtonsoft.Json;

namespace AppAlquiler.Broker
{
    class bEmpleado
    {
        private string BaseServicio = "http://jhonmateus-001-site1.ftempurl.com";
        private string BaseLocal = "http://localhost:62556";
        private string RutaServicio = "/Api/Empleado?Documento=";
        private bool Local;

        public string Documento { get; set; }

        public string Error { get; set; }

        public bEmpleado()
        {
            // Si es true, el servicio ejecuta localmente, si es false, ejecuta en la nube
            Local = true;
        }

        public Empleado Consultar(string Documento)
        {
            //Recupera del servicio "http://jhonmateus-001-site1.ftempurl.com/api/Cliente" la lista de los productos
            try
            {
                //Variable con la ruta del serviicio a consumir
                string sURL;

                if (Local)
                {
                    sURL = BaseLocal + RutaServicio + Documento;
                }
                else
                {
                    sURL = BaseServicio + RutaServicio + Documento;
                }

                //Clase para invocar el servicio rest
                HttpClient httpClient = new();

                //Invoca el servicio y lleva la respuesta a una variable de tipo string
                string Respuesta = httpClient.GetStringAsync(sURL).Result;

                //Procesa la respuesta de tipo string y la convierte en una clase con JsonConvert 
                Empleado empleado = JsonConvert.DeserializeObject<Empleado>(Respuesta);

                return empleado;

            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                return null;
            }
        }
    }
}
