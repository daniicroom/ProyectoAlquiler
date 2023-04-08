using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlquilerVehiculo.Models
{
    public class viewDepartamento
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public int IdPais { get; set; }
        public viewPais Pais { get; set; }
    }
}