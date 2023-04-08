using AlquilerVehiculo.Models;
using libComunes.CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlquilerVehiculo.Class
{
    public class clsEmpleado
    {
        public viewEmpleado vEmpleado { get; set; }
        //Métodos CRUD del empleado
        public string Insertar()
        {
            //Crear el objeto conexión 
            clsConexion oConexion = new clsConexion();
            string SQL = "Registrar_Empleado";
            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@prDocumento", System.Data.SqlDbType.VarChar, 20, vEmpleado.Documento);
            oConexion.AgregarParametro("@prNombres", System.Data.SqlDbType.VarChar, 50, vEmpleado.Nombres);
            oConexion.AgregarParametro("@prApellidos", System.Data.SqlDbType.VarChar, 50, vEmpleado.Apellidos);
            oConexion.AgregarParametro("@prIdTipoDocumento", System.Data.SqlDbType.Int, 5, vEmpleado.IdCargoEmpleado);

            if (oConexion.EjecutarSentencia())
            {
                oConexion.CerrarConexion();
                return "Se ingresó el empleado";
            }
            else
            {
                oConexion.CerrarConexion();
                return oConexion.Error;
            }
        }
        public string Actualizar()
        {
            //Crear el objeto conexión 
            clsConexion oConexion = new clsConexion();
            string SQL = "Actualizar_Empleado";
            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@prDocumento", System.Data.SqlDbType.VarChar, 20, vEmpleado.Documento);
            oConexion.AgregarParametro("@prNombres", System.Data.SqlDbType.VarChar, 50, vEmpleado.Nombres);
            oConexion.AgregarParametro("@prApellidos", System.Data.SqlDbType.VarChar, 50, vEmpleado.Apellidos);
            oConexion.AgregarParametro("@prIdTipoDocumento", System.Data.SqlDbType.Int, 5, vEmpleado.IdCargoEmpleado);
            if (oConexion.EjecutarSentencia())
            {
                oConexion.CerrarConexion();
                return "Se actualizó el empleado";
            }
            else
            {
                oConexion.CerrarConexion();
                return oConexion.Error;
            }
        }
        public string Eliminar()
        {
            //Crear el objeto conexión 
            clsConexion oConexion = new clsConexion();
            string SQL = "Borrar_Empleado";
            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@prDocumento", System.Data.SqlDbType.VarChar, 20, vEmpleado.Documento);

            if (oConexion.EjecutarSentencia())
            {
                oConexion.CerrarConexion();
                return "Se eliminó el empleado";
            }
            else
            {
                oConexion.CerrarConexion();
                return oConexion.Error;
            }
        }
        public viewEmpleado Consultar(string Documento)
        {
            clsConexion oConexion = new clsConexion();
            string SQL = "Consultar_Empleado";
            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@prDocumento", System.Data.SqlDbType.VarChar, 20, vEmpleado.Documento);

            if (oConexion.Consultar())
            {
                //Captura los datos del empleado
                vEmpleado = new viewEmpleado();
                //Es necesario poner a leer los datos con el método .Read()
                oConexion.Reader.Read();
                vEmpleado.Nombres = oConexion.Reader.GetString(0);
                vEmpleado.Apellidos = oConexion.Reader.GetString(1);
                vEmpleado.IdCargoEmpleado = oConexion.Reader.GetInt32(2);

                oConexion.CerrarConexion();
                return vEmpleado;
            }
            else
            {
                oConexion.CerrarConexion();
                return null;
            }
        }
    }
}