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
    public class bAlquiler
    {
        private string BaseServicio = "http://madasolutions-001-site1.etempurl.com";
        private string BaseLocal = "http://localhost:62556";
        private string RutaServicio = "/api/Alquiler?Placa=";
        private bool Local;

        //Vamos a utilizar la conexión a nuestra base de datos
        readonly SQLiteAsyncConnection _connection;

        public string Error { get; set; }
        public bAlquiler()
        {
            // Si es true, el servicio ejecuta localmente, si es false, ejecuta en la nube
            Local = false;
        }
        public bAlquiler(string rutaDB)
        {
            //Asignamos la conexión
            _connection = new SQLiteAsyncConnection(rutaDB);
            // Si es true, el servicio ejecuta localmente, si es false, ejecuta en la nube
            Local = false;
        }
        public async Task<Alquiler> GetAlquilerByPlaca(string placa)
        {
            try
            {
                //Variable con la ruta del serviicio a consumir
                string sURL;

                if (Local)
                {
                    sURL = BaseLocal + RutaServicio + placa;
                }
                else
                {
                    sURL = BaseServicio + RutaServicio + placa;
                }

                //Clase para invocar el servicio rest
                HttpClient httpClient = new();
                //Invoca el servicio y lleva la respuesta a una variable de tipo string
                var Respuesta = httpClient.GetStringAsync(sURL).Result;
                if(Respuesta == "null")
                {
                    return null;
                }
                //Procesa la respuesta de tipo string y la convierte en una clase con JsonConvert 
                Alquiler alquiler = JsonConvert.DeserializeObject<Alquiler>(Respuesta);

                return alquiler;
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                return null;
            }
        }
    }
}
