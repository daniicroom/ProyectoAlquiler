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
            Local = true;
        }
        public bReserva(string rutaDB)
        {
            //Asignamos la conexión
            _connection = new SQLiteAsyncConnection(rutaDB);
            // Si es true, el servicio ejecuta localmente, si es false, ejecuta en la nube
            Local = true;
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
    }
}
