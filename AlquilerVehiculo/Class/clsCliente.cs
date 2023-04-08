using AlquilerVehiculo.Models;
using libComunes.CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlquilerVehiculo.Class
{
    public class clsCliente
    {
        public viewCliente vCliente { get; set; }
        //Métodos CRUD del cliente
        public string Insertar()
        {
            //Crear el objeto conexión 
            clsConexion oConexion = new clsConexion();
            string SQL = "Cliente_Ingresar";
            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@prDocumento", System.Data.SqlDbType.VarChar, 20, vCliente.Documento);
            oConexion.AgregarParametro("@prIdTipoDocumento", System.Data.SqlDbType.Int, 5, vCliente.IdTipoDocumento);
            oConexion.AgregarParametro("@prNombres", System.Data.SqlDbType.VarChar, 50, vCliente.Nombres);
            oConexion.AgregarParametro("@prApellidos", System.Data.SqlDbType.VarChar, 50, vCliente.Apellidos);
            oConexion.AgregarParametro("@prEdad", System.Data.SqlDbType.Int, 5, vCliente.Edad);
            oConexion.AgregarParametro("@prNumeroLicencia", System.Data.SqlDbType.VarChar, 80, vCliente.NumeroLicencia);
            oConexion.AgregarParametro("@prIdLicencia", System.Data.SqlDbType.Int, 5, vCliente.IdLicencia);

            if (oConexion.EjecutarSentencia())
            {
                oConexion.CerrarConexion();
                return "Se ingresó el cliente";
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
            string SQL = "Cliente_Actualizar";
            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@prDocumento", System.Data.SqlDbType.VarChar, 20, vCliente.Documento);
            oConexion.AgregarParametro("@prIdTipoDocumento", System.Data.SqlDbType.Int, 5, vCliente.IdTipoDocumento);
            oConexion.AgregarParametro("@prNombres", System.Data.SqlDbType.VarChar, 50, vCliente.Nombres);
            oConexion.AgregarParametro("@prApellidos", System.Data.SqlDbType.VarChar, 50, vCliente.Apellidos);
            oConexion.AgregarParametro("@prEdad", System.Data.SqlDbType.Int, 5, vCliente.Edad);
            oConexion.AgregarParametro("@prNumeroLicencia", System.Data.SqlDbType.VarChar, 80, vCliente.NumeroLicencia);
            oConexion.AgregarParametro("@prIdLicencia", System.Data.SqlDbType.Int, 5, vCliente.IdLicencia);

            if (oConexion.EjecutarSentencia())
            {
                oConexion.CerrarConexion();
                return "Se actualizó el cliente";
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
            string SQL = "Cliente_Eliminar";
            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@prDocumento", System.Data.SqlDbType.VarChar, 20, vCliente.Documento);

            if (oConexion.EjecutarSentencia())
            {
                oConexion.CerrarConexion();
                return "Se eliminó el cliente";
            }
            else
            {
                oConexion.CerrarConexion();
                return oConexion.Error;
            }
        }
        public viewCliente Consultar(string Documento)
        {
            clsConexion oConexion = new clsConexion();
            string SQL = "Cliente_Consultar";
            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@prDocumento", System.Data.SqlDbType.VarChar, 20, vCliente.Documento);

            if (oConexion.Consultar())
            {
                //Captura los datos del cliente
                vCliente = new viewCliente();
                //Es necesario poner a leer los datos con el método .Read()
                oConexion.Reader.Read();
                vCliente.IdTipoDocumento = oConexion.Reader.GetInt32(0);
                vCliente.Nombres = oConexion.Reader.GetString(1);
                vCliente.Apellidos = oConexion.Reader.GetString(2);
                vCliente.Edad = oConexion.Reader.GetInt32(3);
                vCliente.NumeroLicencia = oConexion.Reader.GetString(4);
                vCliente.IdLicencia = oConexion.Reader.GetInt32(5);

                oConexion.CerrarConexion();
                return vCliente;
            }
            else
            {
                oConexion.CerrarConexion();
                return null;
            }
        }
    }
}