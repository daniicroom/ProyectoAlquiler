using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlquilerVehiculo.Models
{
    public class viewVehiculo
    {
        public string Placa { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public int IdSede { get; set; }
        public viewSede Sede { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string NumeroLicencia { get; set; }
        public int IdLicencia { get; set; }
        public string Comando { get; set; }
    }
}