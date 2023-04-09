using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquiler.Models
{
    public class viewDatosAlquiler
    {
        public int CodigoAlquiler { get; set; }
        public int Precio { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
    }
}