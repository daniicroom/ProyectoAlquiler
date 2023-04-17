using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServicioAlquiler.Models;

namespace ServicioAlquiler.Class
{
    public class clsSede
    {
        private DBAlquilerVehiculoEntities5 dbAlquiler = new DBAlquilerVehiculoEntities5();

        public List<viewCombo> ListarSedes()
        {
            return dbAlquiler.tblSedes
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