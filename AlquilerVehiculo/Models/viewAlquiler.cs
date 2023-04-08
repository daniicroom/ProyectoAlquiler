using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlquilerVehiculo.Models
{
    public class viewAlquiler
    {
        public int Codigo { get; set; }
        public string CedulaCliente { get; set; }
        public viewCliente Cliente { get; set; }
        public string IdEmpleado { get; set; }
        public viewEmpleado CargoEmpleado { get; set; }
        public string PlacaVehiculo { get; set; }
        public viewVehiculo Vehiculo { get; set; }
        public string EstadoAlquiler { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}