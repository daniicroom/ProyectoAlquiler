using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquiler.Class
{
    public class clsTipoDocumento
    {
        private DBAlquilerVehiculoEntities1 dbAlquiler = new DBAlquilerVehiculoEntities1();
        public tblTipoDocumento tipoDocumento { get; set; }
        public List<tblTipoDocumento> GetAll()
        {
            return dbAlquiler.tblTipoDocumentoes.OrderBy(x => x.Nombre).ToList();
        }
    }
}