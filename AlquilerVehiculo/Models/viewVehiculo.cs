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
        public int IdMarca { get; set; }
        public viewMarca Marca { get; set; }
        public int IdGama { get; set; }
        public viewGama Gama { get; set; }
        public int IdColor { get; set; }
        public viewColor Color { get; set; }
        public int Precio { get; set; }
        public int IdTipoVehiculo { get; set; }
        public viewTipoVehiculo TipoVehiculo { get; set; }
        public string Comando { get; set; }
    }
}