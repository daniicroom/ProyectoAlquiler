using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquiler.Class
{
    public class clsEmpleado
    {
        private DBAlquilerVehiculoEntities5 dbAlquiler = new DBAlquilerVehiculoEntities5();
        public tblEmpleado Empleado { get; set; }


        // DEVUELVE EL COMBO DE EMPLEADOS
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


        //CRUD
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
            return "SE REGISTRÓ EL EMPLEADO CON NÚMERO DE DOCUMENTO: " + Empleado.Documento.ToString();
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
            return "SE ACTUALIZARÓN LOS DATOS DEL EMPLEADO";
        }

        public string Eliminar(string Documento)
        {
            tblEmpleado _empleado = dbAlquiler.tblEmpleadoes
                        .Where(p => p.Documento == Documento)
                        .FirstOrDefault();

            dbAlquiler.tblEmpleadoes.Remove(_empleado);
            dbAlquiler.SaveChanges();
            return "SE ELIMINÓ EL EMPLEADO";
        }
        
    }
}