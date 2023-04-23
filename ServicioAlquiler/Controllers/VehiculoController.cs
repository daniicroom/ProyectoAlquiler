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

        [HttpGet]
        [Route("GetTable")]
        public IQueryable<viewDataTableVehiculos> GetTable()
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.LlenarTablaVehiculos();

        }
        

        //Se obtiene la lista de vehiculos por el tipo seleccionado (PARA ALQUILER)
        [HttpGet]
        [Route("GetComboVehiculosXTipo")]
        public List<viewComboVehiculo> GetComboVehiculosXTipo(int Codigo)
        {
            clsVehiculo vehiculo = new clsVehiculo();

            return vehiculo.LlenarComboVehiculosXTipo(Codigo);
        }
        [HttpGet]
        [Route("GetAllComboVehiculosXTipo")]
        public List<viewComboVehiculo> GetAllComboVehiculosXTipo(int Codigo, string Placa)
        {
            clsVehiculo vehiculo = new clsVehiculo();

            return vehiculo.LlenarAllComboVehiculosXTipo(Codigo, Placa);
        }
        public List<viewComboVehiculo> Get(int Codigo)
        {
            clsVehiculo vehiculo = new clsVehiculo();

            return vehiculo.LlenarComboVehiculosXTipo(Codigo);
        }

        
        public IQueryable<viewComboVehiculo> Get()
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.LlenarComboVehiculo();
        }

        public tblVehiculo Get(string placa)
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.Consultar(placa);
        }
        public tblVehiculo GetByIdAlquiler(int idAlquiler)
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.GetByIdAlquiler(idAlquiler);
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