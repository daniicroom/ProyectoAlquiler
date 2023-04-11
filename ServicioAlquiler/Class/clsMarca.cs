using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServicioAlquiler.Models;

namespace ServicioAlquiler.Class
{
    public class clsMarca
    {
        private DBAlquilerVehiculoEntities1 dbAlquiler = new DBAlquilerVehiculoEntities1();
        public tblMarca marca { get; set; }
        public List<viewCombo> ListarMarcas()
        {
            return dbAlquiler.tblMarcas
                .OrderBy(x => x.Nombre)
                .Select(p => new viewCombo
                {
                    Codigo = p.Codigo,
                    Nombre = p.Nombre
                })
                .ToList();
        }
    }
}