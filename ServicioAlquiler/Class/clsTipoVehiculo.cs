using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServicioAlquiler.Models;

namespace ServicioAlquiler.Class
{
    public class clsTipoVehiculo
    {
        private DBAlquilerVehiculoEntities5 dbAlquiler = new DBAlquilerVehiculoEntities5();

        public List<viewCombo> ListarTipoVehiculo()
        {
            return dbAlquiler.tblTipoVehiculoes
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