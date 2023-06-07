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
    public class bCliente
    {
        private string BaseServicio = "http://madasolutions-001-site1.etempurl.com";
        private string BaseLocal = "http://localhost:62556";
        private string RutaServicio = "/Api/Cliente?Documento=";
        private bool Local;

        //Vamos a utilizar la conexión a nuestra base de datos
        readonly SQLiteAsyncConnection _connection;
        public string Documento { get; set; }

        public string Error { get; set; }
        public int GetFromServicio()
        {
            //Eliminar los clientes en la base de datos
            EliminarCliente();
            //return InsertarClientesServicio().Result;
            return 1;
        }
        public bCliente()
        {
            // Si es true, el servicio ejecuta localmente, si es false, ejecuta en la nube
            Local = false;
        }
        public bCliente(string rutaDB)
        {
            //Asignamos la conexión
            _connection = new SQLiteAsyncConnection(rutaDB);
            // Si es true, el servicio ejecuta localmente, si es false, ejecuta en la nube
            Local = true;
        }
        
        public Cliente Consultar(string Documento)
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
                Cliente cliente = JsonConvert.DeserializeObject<Cliente>(Respuesta);

                return cliente;

            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                return null;
            }
        }
        public Task<int> EliminarCliente()
        {
            //Elimina los datos de la tabla cliente
            return _connection.DeleteAllAsync<Cliente>();
        }
        public async Task<int> Eliminar(string documento)
        {
            try
            {
                Cliente _cliente = await (_connection.Table<Cliente>()
                        .Where(p => p.Documento == documento)
                        .FirstOrDefaultAsync());
                return _connection.DeleteAsync(_cliente).Result;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return -1;
            }
        }
        public async Task<int> GrabarCliente(Cliente cliente)
        {
            Cliente _cliente = await (_connection.Table<Cliente>()
                    .Where(p => p.Documento == cliente.Documento)
                    .FirstOrDefaultAsync());
            if (_cliente == null)
            {
                //Se va a grabar
                return _connection.InsertAsync(cliente).Result;
            }
            else
            {
                //Se va a actualizar
                return _connection.UpdateAsync(cliente).Result;
            }
        }
        /*public Task<int> InsertarClientesServicio(Cliente cliente)
        {
            //Inserta los clientes en la base de datos de clientes
            //return _connection.InsertAllAsync(cliente);
        }*/
    }
}
