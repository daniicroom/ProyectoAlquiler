using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServicioAlquiler.Models;

namespace ServicioAlquiler.Class
{
    public class clsGama
    {
        private DBAlquilerVehiculoEntities1 dbAlquiler = new DBAlquilerVehiculoEntities1();

        public List<viewCombo> ListarGama()
        {
            return dbAlquiler.tblGamas
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