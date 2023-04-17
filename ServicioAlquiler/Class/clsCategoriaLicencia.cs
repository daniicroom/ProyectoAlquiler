using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquiler.Class
{
    public class clsCategoriaLicencia
    {
        private DBAlquilerVehiculoEntities5 dbAlquiler = new DBAlquilerVehiculoEntities5();
        public tblLicencia licencia { get; set; }
        public List<viewCombo> GetAll()
        {
            return dbAlquiler.tblLicencias
            .Select(p => new viewCombo
            {
                Codigo = p.Codigo,
                Nombre = p.CategoriaLicencia
            }).OrderBy(x => x.Nombre)
            .ToList();
        }
    }
}