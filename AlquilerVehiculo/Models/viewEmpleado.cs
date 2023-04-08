using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlquilerVehiculo.Models
{
    public class viewEmpleado
    {
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apelligos { get; set; }
        public string IdCargoEmpleado { get; set; }
        public viewCargoEmpleado CargoEmpleado { get; set; }
        public string Comando { get; set; }
    }
}