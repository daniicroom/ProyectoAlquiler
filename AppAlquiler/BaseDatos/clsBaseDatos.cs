using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAlquiler.Broker;
using AppAlquiler.Models;
using SQLite;

namespace AppAlquiler.BaseDatos
{
    public class clsBaseDatos
    {
        //Definimos los atributos de la base de datos
        private readonly SQLiteAsyncConnection _connection;
        private bool bCliente, /*bEmpleado,*/ bReserva, bDevolucion;
        private const SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLiteOpenFlags.SharedCache;

        public clsBaseDatos(string Ruta) 
        {
            //Recibe la ruta donde se va a crear la base de datos
            _connection = new SQLiteAsyncConnection(Ruta, Flags);

           bCliente = true;/* bEmpleado= true;*/ bReserva= true; bDevolucion = true;
        }
        public void CrearTablas()
        {
            if (bCliente) { _connection.CreateTableAsync<Cliente>().Wait(); }
            //if (bEmpleado) { _connection.CreateTableAsync<Empleado>().Wait(); }
            if (bReserva) { _connection.CreateTableAsync<Reservar>().Wait(); }
            if (bDevolucion) { _connection.CreateTableAsync<Devolucion>().Wait(); }
        }
    }
}
