using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAlquiler.Models;
using Newtonsoft.Json;


namespace AppAlquiler.Broker
{
    public class bTipoVehiculo
    {
        private string BaseServicio = "http://madasolutions-001-site1.etempurl.com";
        private string BaseLocal = "http://localhost:62556";
        private string RutaServicio = "/api/TipoVehiculo";
        private bool Local;
       

        public string Error { get; set; }


        public bTipoVehiculo()
        {
            // Si es true, el servicio ejecuta localmente, si es false, ejecuta en la nube
            Local = false;
        }


        public List<TipoVehiculo> GetTiposVehiculos()
        {
            //Recupera del servicio "http://madasolutions-001-site1.etempurl.com/api/TipoVehiculo" la lista de los productos
            try
            {
                //Variable con la ruta del serviicio a consumir
                string sURL;

                if (Local)
                {
                    sURL = BaseLocal + RutaServicio;
                }
                else
                {
                    sURL = BaseServicio + RutaServicio;
                }

                //Clase para invocar el servicio rest
                HttpClient httpClient = new();

                //Invoca el servicio y lleva la respuesta a una variable de tipo string
                string Respuesta = httpClient.GetStringAsync(sURL).Result;

                //Procesa la respuesta de tipo string y la convierte en una clase con JsonConvert 
                List<TipoVehiculo> tipoVehiculo = JsonConvert.DeserializeObject<List<TipoVehiculo>>(Respuesta);

                return tipoVehiculo;

            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                return null;
            }
        }
    }
}
