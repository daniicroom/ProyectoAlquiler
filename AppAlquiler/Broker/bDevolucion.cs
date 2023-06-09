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
    public class bDevolucion
    {
        private string BaseServicio = "http://madasolutions-001-site1.etempurl.com";
        private string BaseLocal = "http://localhost:62556";
        private bool Local;

        //Vamos a utilizar la conexión a nuestra base de datos
        readonly SQLiteAsyncConnection _connection;

        public string Error { get; set; }
        public bDevolucion()
        {
            // Si es true, el servicio ejecuta localmente, si es false, ejecuta en la nube
            Local = false;
        }
        public bDevolucion(string rutaDB)
        {
            //Asignamos la conexión
            _connection = new SQLiteAsyncConnection(rutaDB);
            // Si es true, el servicio ejecuta localmente, si es false, ejecuta en la nube
            Local = false;
        }
        public async Task<int> GrabarDevolucion(Devolucion devolucion)
        {
            Devolucion _devolucion = await (_connection.Table<Devolucion>()
                    .Where(p => p.CodigoAlquiler == devolucion.CodigoAlquiler)
                    .FirstOrDefaultAsync());
            if (_devolucion == null)
            {
                //Se va a grabar
                return _connection.InsertAsync(devolucion).Result;
            }
            else
            {
                //Se va a actualizar
                return _connection.UpdateAsync(devolucion).Result;
            }
        }
        public async Task<string> GrabarDevolucionServicio(Devolucion devolucion)
        {
            try
            {
                //Variable con la ruta del serviicio a consumir
                string sURL;

                if (Local)
                {
                    sURL = BaseLocal + "/Api/Devolucion";
                }
                else
                {
                    sURL = BaseServicio + "/Api/Devolucion";
                }

                //Clase para invocar el servicio rest
                HttpClient httpClient = new();
                string jsonDevolucion = JsonConvert.SerializeObject(devolucion);
                HttpContent content = new StringContent(jsonDevolucion, Encoding.UTF8, "application/json");

                // Realizar la solicitud POST y obtener la respuesta
                HttpResponseMessage response = await httpClient.PostAsync(sURL, content);

                // Leer el contenido de la respuesta como una cadena
                string responseContent = await response.Content.ReadAsStringAsync();

                return responseContent;

            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                return null;
            }
        }
    }
}
