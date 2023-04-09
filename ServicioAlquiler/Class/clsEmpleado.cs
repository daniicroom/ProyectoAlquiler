using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquiler.Class
{
    public class clsEmpleado
    {
        private DBAlquilerVehiculoEntities dbAlquiler = new DBAlquilerVehiculoEntities();
        public tblEmpleado Empleado { get; set; }
        public tblEmpleado Consultar(string Documento)
        {
            return dbAlquiler.tblEmpleado
                    .Where(x => x.Documento == Documento)
                    .FirstOrDefault();
        }
        public string GrabarEmpleado()
        {
            dbAlquiler.tblEmpleado.Add(Empleado);
            dbAlquiler.SaveChanges();
            return "Se ingresó el empleado" + Empleado.Documento.ToString();
        }
        public string Actualizar()
        {
            tblEmpleado _empleado = dbAlquiler.tblEmpleado
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
            tblEmpleado _empleado = dbAlquiler.tblEmpleado
                        .Where(p => p.Documento == Documento)
                        .FirstOrDefault();

            dbAlquiler.tblEmpleado.Remove(_empleado);
            dbAlquiler.SaveChanges();
            return "Se eliminó el empleado";
        }
        public IQueryable<viewCombo> LlenarComboEmpleados()
        {
            return from empl in dbAlquiler.Set<tblEmpleado>()
                   join emplcarg in dbAlquiler.Set<tblCargoEmpleado>()
                   on empl.IDCargoEmpleado equals emplcarg.Codigo
                   orderby empl.Nombres + " " + empl.Apellidos
                   select new viewCombo
                   {
                       Codigo = emplcarg.Codigo,
                       Nombre = empl.Nombres + " " + empl.Apellidos
                   };
        }
    }
}