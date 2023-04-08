using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlquilerVehiculo.Models
{
    public class viewCiudad
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public int CodigoDepartamento { get; set; }
        public viewDepartamento Departamento { get; set; }
    }
}