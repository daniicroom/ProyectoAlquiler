using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquiler.Class
{
    public class clsCategoriaLicencia
    {
        private DBAlquilerVehiculoEntities dbAlquiler = new DBAlquilerVehiculoEntities();
        public tblLicencia licencia { get; set; }
        public List<viewCombo> GetAll()
        {
            return dbAlquiler.tblLicencia
            .Select(p => new viewCombo
            {
                Codigo = p.Codigo,
                Nombre = p.CategoriaLicencia
            }).OrderBy(x => x.Nombre)
            .ToList();
        }
    }
}