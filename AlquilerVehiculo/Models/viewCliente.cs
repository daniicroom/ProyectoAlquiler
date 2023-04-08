using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlquilerVehiculo.Models
{
    public class viewCliente
    {
        public string Documento { get; set; }
        public int IdTipoDocumento { get; set; }
        public viewTipoDocumento TipoDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string NumeroLicencia { get; set; }
        public int IdLicencia { get; set; }
        public viewLicencia Licencia { get; set; }
        public string Comando { get; set; }
    }
}