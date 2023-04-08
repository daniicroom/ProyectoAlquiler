using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquiler.Class
{
    public class clsTipoDocumento
    {
        private DBAlquilerVehiculoEntities dbAlquiler = new DBAlquilerVehiculoEntities();
        public tblTipoDocumento tipoDocumento { get; set; }
        public List<tblTipoDocumento> GetAll()
        {
            return dbAlquiler.tblTipoDocumento.OrderBy(x => x.Nombre).ToList();
        }
    }
}