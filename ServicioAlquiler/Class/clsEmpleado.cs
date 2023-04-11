using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquiler.Class
{
    public class clsEmpleado
    {
        private DBAlquilerVehiculoEntities1 dbAlquiler = new DBAlquilerVehiculoEntities1();
        public tblEmpleado Empleado { get; set; }
        public tblEmpleado Consultar(string Documento)
        {
            return dbAlquiler.tblEmpleadoes
                    .Where(x => x.Documento == Documento)
                    .FirstOrDefault();
        }

        public string GrabarEmpleado()
        {
            dbAlquiler.tblEmpleadoes.Add(Empleado);
            dbAlquiler.SaveChanges();
            return "Se ingresó el empleado con número de documento: " + Empleado.Documento.ToString();
        }

        public string Actualizar()
        {
            tblEmpleado _empleado = dbAlquiler.tblEmpleadoes
                        .Where(p => p.Documento == Empleado.Documento)
                        .FirstOrDefault();

            _empleado.Nombres = Empleado.Nombres;
            _empleado.Apellidos = Empleado.Apellidos;
            _empleado.IDCargoEmpleado = Empleado.IDCargoEmpleado;

            dbAlquiler.SaveChanges();
            return "Se actualizó el empleado";
        }

        public string Eliminar(string Documento)
        {
            tblEmpleado _empleado = dbAlquiler.tblEmpleadoes
                        .Where(p => p.Documento == Documento)
                        .FirstOrDefault();

            dbAlquiler.tblEmpleadoes.Remove(_empleado);
            dbAlquiler.SaveChanges();
            return "Se eliminó el empleado";
        }
        public IQueryable<viewComboVehiculo> LlenarComboEmpleados()
        {
            return from empl in dbAlquiler.Set<tblEmpleado>()
                   join emplcarg in dbAlquiler.Set<tblCargoEmpleado>()
                   on empl.IDCargoEmpleado equals emplcarg.Codigo
                   orderby empl.Nombres + " " + empl.Apellidos
                   select new viewComboVehiculo
                   {
                       Codigo = empl.Documento,
                       Nombre = empl.Nombres + " " + empl.Apellidos
                   };
        }
    }
}