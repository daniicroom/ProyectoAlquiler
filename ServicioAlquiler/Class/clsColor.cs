using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServicioAlquiler.Models;

namespace ServicioAlquiler.Class
{
    
    public class clsColor
    {
        private DBAlquilerVehiculoEntities5 dbAlquiler = new DBAlquilerVehiculoEntities5();

        // DEVUELVE EL COMBO DE COLORES DE VEHICULOS
        public List<viewCombo> ListarColorVehiculo()
        {
            return dbAlquiler.tblColors
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