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
        public List<tblLicencia> GetAll()
        {
            return dbAlquiler.tblLicencia.OrderBy(x => x.CategoriaLicencia).ToList();
        }
    }
}