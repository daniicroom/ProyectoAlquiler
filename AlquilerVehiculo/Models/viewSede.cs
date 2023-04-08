using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlquilerVehiculo.Models
{
    public class viewSede
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int IdCiudadSede { get; set; }
        public viewCiudad CiudadSede { get; set; }
    }
}