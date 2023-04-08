using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquiler.Class
{
    public class clsCliente
    {
        private DBAlquilerVehiculoEntities dbAlquiler = new DBAlquilerVehiculoEntities();
        public tblCliente cliente { get; set; }
        public tblCliente Consultar(string Documento)
        {
            return dbAlquiler.tblCliente
                    .Where(x => x.Documento == Documento)
                    .FirstOrDefault();
        }
    }
}