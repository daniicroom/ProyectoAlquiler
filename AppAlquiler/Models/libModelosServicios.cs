using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAlquiler.Models
{
    public class TipoDocumento
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
    }


    public class TipoVehiculo
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
    }



    public class Vehiculo
    {
        public string Placa { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public int IDSede { get; set; }
        public int IDMarca { get; set; }
        public int IDGama { get; set; }
        public int IDColor { get; set; }
        public int Precio { get; set; }
        public int IDTipoVehiculo { get; set; }
    }









    /*
    public class Cliente
    {
        public string Documento { get; set; }
        public int TipoDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }
        public string NumeroLicencia { get; set; }
        public int IDLicencia { get; set; }


    }

    public class Empleado
    {
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int IDCargoEmpleado { get; set; }


    }
 
  
    public class Reservar
    {
        public int Codigo { get; set; }
        public string CedulaCliente { get; set; }
        public string IDEmpleado { get; set; }
        public int IDTipoVehiculo { get; set; }
        public string PlacaVehiculo { get; set; }
        public string EstadoReserva { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaFin { get; set; }
    }
    public class Devolucion
    {
        public int Codigo { get; set; }
        public int CodigoAlquiler { get; set; }
        public string IDEmpleadoRecibe { get; set; }
        public System.DateTime FechaDevolucion { get; set; }
        public int TotalPagar { get; set; }
    }*/

}
