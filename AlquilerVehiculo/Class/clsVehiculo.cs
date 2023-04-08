using AlquilerVehiculo.Models;
using libComunes.CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlquilerVehiculo.Class
{
    public class clsVehiculo
    {
        public viewVehiculo vVehiculo { get; set; }
        //Métodos CRUD del cliente
        /*public string Insertar()
        {
            //Crear el objeto conexión 
            clsConexion oConexion = new clsConexion();
            string SQL = "Cliente_Ingresar";
            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@prPlaca", System.Data.SqlDbType.VarChar, 20, vVehiculo.Placa);
            oConexion.AgregarParametro("@prDescripcion", System.Data.SqlDbType.VarChar, 80, vVehiculo.Descripcion);
            oConexion.AgregarParametro("@prEstado", System.Data.SqlDbType.VarChar, 20, vVehiculo.Estado);
            oConexion.AgregarParametro("@prIdSede", System.Data.SqlDbType.Int, 5, vVehiculo.IdSede);
            oConexion.AgregarParametro("@prIdMarca", System.Data.SqlDbType.Int, 5, vVehiculo.IdMarca);
            oConexion.AgregarParametro("@prIdGama", System.Data.SqlDbType.Int, 5, vVehiculo.IdGama);
            oConexion.AgregarParametro("@prIdColor", System.Data.SqlDbType.Int, 5, vVehiculo.IdColor);
            oConexion.AgregarParametro("@prPrecio", System.Data.SqlDbType.Int, 20, vVehiculo.Precio);
            oConexion.AgregarParametro("@prIdTipoVehiculo", System.Data.SqlDbType.Int, 5, vVehiculo.IdTipoVehiculo);

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
            oConexion.AgregarParametro("@prPlaca", System.Data.SqlDbType.VarChar, 20, vVehiculo.Placa);
            oConexion.AgregarParametro("@prDescripcion", System.Data.SqlDbType.VarChar, 80, vVehiculo.Descripcion);
            oConexion.AgregarParametro("@prEstado", System.Data.SqlDbType.VarChar, 20, vVehiculo.Estado);
            oConexion.AgregarParametro("@prIdSede", System.Data.SqlDbType.Int, 5, vVehiculo.IdSede);
            oConexion.AgregarParametro("@prIdMarca", System.Data.SqlDbType.Int, 5, vVehiculo.IdMarca);
            oConexion.AgregarParametro("@prIdGama", System.Data.SqlDbType.Int, 5, vVehiculo.IdGama);
            oConexion.AgregarParametro("@prIdColor", System.Data.SqlDbType.Int, 5, vVehiculo.IdColor);
            oConexion.AgregarParametro("@prPrecio", System.Data.SqlDbType.Int, 20, vVehiculo.Precio);
            oConexion.AgregarParametro("@prIdTipoVehiculo", System.Data.SqlDbType.Int, 5, vVehiculo.IdTipoVehiculo);

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
        }*/
        public string Devolver()
        {
            //Crear el objeto conexión 
            clsConexion oConexion = new clsConexion();
            string SQL = "Devolver_Vehiculo";
            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@prPlaca", System.Data.SqlDbType.VarChar, 20, vVehiculo.Placa);
            oConexion.AgregarParametro("@prDescripcion", System.Data.SqlDbType.VarChar, 80, vVehiculo.Descripcion);
            oConexion.AgregarParametro("@prEstado", System.Data.SqlDbType.VarChar, 20, vVehiculo.Estado);
            oConexion.AgregarParametro("@prIdSede", System.Data.SqlDbType.Int, 5, vVehiculo.IdSede);
            oConexion.AgregarParametro("@prIdMarca", System.Data.SqlDbType.Int, 5, vVehiculo.IdMarca);
            oConexion.AgregarParametro("@prIdGama", System.Data.SqlDbType.Int, 5, vVehiculo.IdGama);
            oConexion.AgregarParametro("@prIdColor", System.Data.SqlDbType.Int, 5, vVehiculo.IdColor);
            oConexion.AgregarParametro("@prPrecio", System.Data.SqlDbType.Int, 20, vVehiculo.Precio);
            oConexion.AgregarParametro("@prIdTipoVehiculo", System.Data.SqlDbType.Int, 5, vVehiculo.IdTipoVehiculo);

            if (oConexion.EjecutarSentencia())
            {
                oConexion.CerrarConexion();
                return "Se ha hecho la devolución correctamente";
            }
            else
            {
                oConexion.CerrarConexion();
                return oConexion.Error;
            }
        }
        public string Alquilar()
        {
            //Crear el objeto conexión 
            clsConexion oConexion = new clsConexion();
            string SQL = "Alquilar_Vehiculo";
            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@prPlaca", System.Data.SqlDbType.VarChar, 20, vVehiculo.Placa);
            oConexion.AgregarParametro("@prDescripcion", System.Data.SqlDbType.VarChar, 80, vVehiculo.Descripcion);
            oConexion.AgregarParametro("@prEstado", System.Data.SqlDbType.VarChar, 20, vVehiculo.Estado);
            oConexion.AgregarParametro("@prIdSede", System.Data.SqlDbType.Int, 5, vVehiculo.IdSede);
            oConexion.AgregarParametro("@prIdMarca", System.Data.SqlDbType.Int, 5, vVehiculo.IdMarca);
            oConexion.AgregarParametro("@prIdGama", System.Data.SqlDbType.Int, 5, vVehiculo.IdGama);
            oConexion.AgregarParametro("@prIdColor", System.Data.SqlDbType.Int, 5, vVehiculo.IdColor);
            oConexion.AgregarParametro("@prPrecio", System.Data.SqlDbType.Int, 20, vVehiculo.Precio);
            oConexion.AgregarParametro("@prIdTipoVehiculo", System.Data.SqlDbType.Int, 5, vVehiculo.IdTipoVehiculo);

            if (oConexion.EjecutarSentencia())
            {
                oConexion.CerrarConexion();
                return "Vehiculo alquilado correctamente";
            }
            else
            {
                oConexion.CerrarConexion();
                return oConexion.Error;
            }
        }
        /*public string Eliminar()
        {
            //Crear el objeto conexión 
            clsConexion oConexion = new clsConexion();
            string SQL = "Cliente_Eliminar";
            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@prPlaca", System.Data.SqlDbType.VarChar, 20, vVehiculo.Placa);

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
        public viewVehiculo Consultar(string Documento)
        {
            clsConexion oConexion = new clsConexion();
            string SQL = "Cliente_Consultar";
            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@prPlaca", System.Data.SqlDbType.VarChar, 20, vVehiculo.Placa);

            if (oConexion.Consultar())
            {
                //Captura los datos del cliente
                vVehiculo = new viewVehiculo();
                //Es necesario poner a leer los datos con el método .Read()
                oConexion.Reader.Read();
                vVehiculo.Descripcion = oConexion.Reader.GetString(0);
                vVehiculo.Estado = oConexion.Reader.GetString(1);
                vVehiculo.IdSede = oConexion.Reader.GetInt32(2);
                vVehiculo.IdMarca = oConexion.Reader.GetInt32(3);
                vVehiculo.IdGama = oConexion.Reader.GetInt32(4);
                vVehiculo.IdColor = oConexion.Reader.GetInt32(5);
                vVehiculo.Precio = oConexion.Reader.GetInt32(6);
                vVehiculo.IdTipoVehiculo = oConexion.Reader.GetInt32(7);

                oConexion.CerrarConexion();
                return vVehiculo;
            }
            else
            {
                oConexion.CerrarConexion();
                return null;
            }
        }*/
    }
}