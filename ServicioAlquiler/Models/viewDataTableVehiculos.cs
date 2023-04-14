using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquiler.Models
{
    public class viewDataTableVehiculos
    {
        public string Placa { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public int IDSede { get; set; }
        public string Sede { get; set; }
        public int IDMarca { get; set; }
        public string Marca { get; set; }
        public int IDGama { get; set; }
        public string Gama { get; set; }
        public int IDColor { get; set; }
        public string Color { get; set; }
        public int IDTipoVehiculo { get; set; }
        public string TipoVehiculo { get; set; }
        public int Precio { get; set; }
    }
}