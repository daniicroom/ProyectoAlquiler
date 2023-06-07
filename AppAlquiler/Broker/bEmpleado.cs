using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAlquiler.Models;
using Newtonsoft.Json;
using SQLite;

namespace AppAlquiler.Broker
{
    public class bEmpleado
    {
        private string BaseServicio = "http://madasolutions-001-site1.etempurl.com";
        private string BaseLocal = "http://localhost:62556";
        private string RutaServicio = "/Api/Empleado?Documento=";
        private bool Local;
        //Vamos a utilizar la conexión a nuestra base de datos
        readonly SQLiteAsyncConnection _connection;
        public string Documento { get; set; }

        public string Error { get; set; }
        public bEmpleado()
        {
            // Si es true, el servicio ejecuta localmente, si es false, ejecuta en la nube
            Local = false;
        }
        public bEmpleado(string rutaDB)
        {
            //Asignamos la conexión
            _connection = new SQLiteAsyncConnection(rutaDB);
            // Si es true, el servicio ejecuta localmente, si es false, ejecuta en la nube
            Local = false;
        }

        public Empleado Consultar(string Documento)
        {
            //Recupera del servicio "http://madasolutions-001-site1.etempurl.com/api/Cliente" la lista de los productos
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
        public async Task<int> GrabarEmpleado(Empleado empleado)
        {
            Empleado _empleado = await (_connection.Table<Empleado>()
                    .Where(p => p.Documento == empleado.Documento)
                    .FirstOrDefaultAsync());
            if (_empleado == null)
            {
                //Se va a grabar
                return _connection.InsertAsync(_empleado).Result;
            }
            else
            {
                //Se va a actualizar
                return _connection.UpdateAsync(empleado).Result;
            }
        }
        public async Task<int> Eliminar(string documento)
        {
            try
            {
                Empleado _empleado = await (_connection.Table<Empleado>()
                        .Where(p => p.Documento == documento)
                        .FirstOrDefaultAsync());
                return _connection.DeleteAsync(_empleado).Result;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return -1;
            }
        }
    }
}
