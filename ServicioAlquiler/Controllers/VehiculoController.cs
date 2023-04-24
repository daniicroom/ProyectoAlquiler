using ServicioAlquiler.Class;
using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ServicioAlquiler.Controllers
{
    [EnableCors(origins: "http://localhost:54777", headers: "*", methods: "*")]
    [RoutePrefix("api/Vehiculo")]
    public class VehiculoController : ApiController
    {

        [HttpGet]
        [Route("GetAll")]
        public IQueryable<tblVehiculo> GetAll()
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.GetAll();
        }

        // PARA LA CONSULTA POR ID DE ALQUILER EN LA DEVOLUCION DEL VEHÍCULO
        public tblVehiculo GetByIdAlquiler(int idAlquiler)
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.GetByIdAlquiler(idAlquiler);
        }


        // PARA EL LLENADO DE LA DATATABLE EN LA PAGINA VEHICULO
        [HttpGet]
        [Route("GetTable")]
        public IQueryable<viewDataTableVehiculos> GetTable()
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.LlenarTablaVehiculos();

        }

        // DEVUELVE EL COMBO DE VEHICULOS EN LA FORMA: MARCA - NOMBRE DEL VEHICULO
        public IQueryable<viewComboVehiculo> Get()
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.LlenarComboVehiculo();
        }

        // DEVUELVE EL COMBO DE VEHICULOS CORRESPONDIENTES UN TIPO Y QUE A DEMÁS ESTÁN EN ESTADO DISPONIBLE
        public List<viewComboVehiculo> Get(int Codigo)
        {
            clsVehiculo vehiculo = new clsVehiculo();

            return vehiculo.LlenarComboVehiculosXTipo(Codigo);
        }

        //SE OBTIENE LA LISTA DE VEHICULOS DISPONIBLES DE ACUERDO AL TIPO SELECCIONADO Y AL DOCUMENTO DEL CLIENTE SI TIENE ALGUNA RESERVA (PARA ALQUILER)
        [HttpGet]
        [Route("GetComboVehiculosXTipoCliente")]
        public List<viewComboVehiculo> GetComboVehiculosXTipoCliente(int Codigo, string Cedula)
        {
            clsVehiculo vehiculo = new clsVehiculo();

            return vehiculo.LlenarComboVehiculosXTipoCliente(Codigo, Cedula);
        }


        //SE OBTIENE LA LISTA DE VEHICULOS DISPONIBLES DE ACUERDO AL TIPO SELECCIONADO (PARA ALQUILER)
        [HttpGet]
        [Route("GetComboVehiculosXTipo")]
        public List<viewComboVehiculo> GetComboVehiculosXTipo(int Codigo)
        {
            clsVehiculo vehiculo = new clsVehiculo();

            return vehiculo.LlenarComboVehiculosXTipo(Codigo);
        }

        //DEVUELVE EL COMBO DE VEHICULOS CORRESPONDIENTES UN TIPO Y QUE A DEMÁS ESTÁN EN ESTADO DISPONIBLE O DONDE EL NÚMERO DE PLACA SEA IGUAL A LA REGISTRADA EN LA DB
        [HttpGet]
        [Route("GetAllComboVehiculosXTipo")]
        public List<viewComboVehiculo> GetAllComboVehiculosXTipo(int Codigo, string Placa)
        {
            clsVehiculo vehiculo = new clsVehiculo();

            return vehiculo.LlenarAllComboVehiculosXTipo(Codigo, Placa);
        }

        

        public tblVehiculo Get(string placa)
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.Consultar(placa);
        }

        
        public string Post([FromBody] tblVehiculo vehiculo)
        {
            clsVehiculo oVehiculo = new clsVehiculo();
            oVehiculo.vehiculo = vehiculo;
            return oVehiculo.Grabarvehiculo();
        }
        public string Put([FromBody] tblVehiculo vehiculo)
        {
            clsVehiculo oVehiculo = new clsVehiculo();
            oVehiculo.vehiculo = vehiculo;
            return oVehiculo.Actualizar();
        }
        public string Delete([FromBody] tblVehiculo vehiculo)
        {
            clsVehiculo oVehiculo = new clsVehiculo();
            return oVehiculo.Deshabilitar(vehiculo.Placa);
        }
    }
}