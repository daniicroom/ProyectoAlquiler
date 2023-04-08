using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlquilerVehiculo.Models
{
    public class viewDevolucion
    {
        public int Codigo { get; set; }
        public int CodigoAlquiler { get; set; }
        public viewAlquiler Alquiler { get; set; }
        public string IdEmpleadoRecibe { get; set; }
        public viewEmpleado Empleado { get; set; }
        public int TotalPagar { get; set; }
    }
}