using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace AppAlquiler.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [PrimaryKey] public string Documento { get; set; }
        public int TipoDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }
        public string NumeroLicencia { get; set; }
        public int IDLicencia { get; set; }


    }
    [Table("Empleado")]
    public class Empleado
    {
        [PrimaryKey] public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int IDCargoEmpleado { get; set; }


    }
    [Table("Reserva")]
    public class Reservar
    {
        [PrimaryKey] public int Codigo { get; set; }
        public string CedulaCliente { get; set; }
        public string IDEmpleado { get; set; }
        public int IDTipoVehiculo { get; set; }
        public string PlacaVehiculo { get; set; }
        public string EstadoReserva { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaFin { get; set; }
    }
    [Table("Devolucion")]
    public class Devolucion
    {
        [PrimaryKey] public int Codigo { get; set; }
        public int CodigoAlquiler { get; set; }
        public string IDEmpleadoRecibe { get; set; }
        public System.DateTime FechaDevolucion { get; set; }
        public int TotalPagar { get; set; }
    }
}
