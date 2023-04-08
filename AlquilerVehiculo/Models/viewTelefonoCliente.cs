using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlquilerVehiculo.Models
{
    public class viewTelefonoCliente
    {
        public int Codigo { get; set; }
        public string Numero { get; set; }
        public string CedulaCliente { get; set; }
        public viewCliente Cliente { get; set; }
        public int IdTipoTelefono { get; set; }
        public viewTipoTelefono TipoTelefono { get; set; }
    }
}