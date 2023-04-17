using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServicioAlquiler.Models;

namespace ServicioAlquiler.Class
{
    public class clsReserva
    {
        private DBAlquilerVehiculoEntities5 dbAlquiler = new DBAlquilerVehiculoEntities5();
        public tblReservar reserva { get; set; }
        public List<tblReservar> GetAll()
        {
            try
            {
                return dbAlquiler.tblReservars.OrderBy(x => x.Codigo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}