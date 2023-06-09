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
    public class bReserva
    {
        private string BaseServicio = "http://madasolutions-001-site1.etempurl.com";
        private string BaseLocal = "http://localhost:62556";
        private bool Local;

        //Vamos a utilizar la conexión a nuestra base de datos
        readonly SQLiteAsyncConnection _connection;

        public string Error { get; set; }
        public bReserva()
        {
            // Si es true, el servicio ejecuta localmente, si es false, ejecuta en la nube
            Local = false;
        }
        public bReserva(string rutaDB)
        {
            //Asignamos la conexión
            _connection = new SQLiteAsyncConnection(rutaDB);
            // Si es true, el servicio ejecuta localmente, si es false, ejecuta en la nube
            Local = false;
        }
        public async Task<int> GrabarReserva(Reservar reserva)
        {
            Reservar _reseva = await (_connection.Table<Reservar>()
                    .Where(p => p.PlacaVehiculo == reserva.PlacaVehiculo)
                    .FirstOrDefaultAsync());
            if (_reseva == null)
            {
                //Se va a grabar
                return _connection.InsertAsync(reserva).Result;
            }
            else
            {
                //Se va a actualizar
                return _connection.UpdateAsync(reserva).Result;
            }
        }
        public async Task<string> GrabarReservaServicio(Reservar reserva)
        {
            try
            {
                //Variable con la ruta del serviicio a consumir
                string sURL;

                if (Local)
                {
                    sURL = BaseLocal + "/Api/Reserva";
                }
                else
                {
                    sURL = BaseServicio + "/Api/Reserva";
                }

                //Clase para invocar el servicio rest
                HttpClient httpClient = new();
                string jsonDevolucion = JsonConvert.SerializeObject(reserva);
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
