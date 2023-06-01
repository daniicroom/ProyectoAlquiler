using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAlquiler.Models
{
    public class Cliente
    {
        public string Documento { get; set; }
        public int TipoDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }
        public string NumeroLicencia { get; set; }
        public int IDLicencia { get; set; }


    }

}
