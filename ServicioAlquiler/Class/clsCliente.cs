using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquiler.Class
{
    public class clsCliente
    {
        private DBAlquilerVehiculoEntities5 dbAlquiler = new DBAlquilerVehiculoEntities5();
        public tblCliente cliente { get; set; }


        //CRUD
        public string Grabarcliente()
        {
            dbAlquiler.tblClientes.Add(cliente);
            dbAlquiler.SaveChanges();
            return "SE REGISTRÓ EL CLIENTE CON NÚMERO DE DOCUMENTO: " + cliente.Documento.ToString();
        }

        public tblCliente Consultar(string Documento)
        {
            return dbAlquiler.tblClientes
                    .Where(x => x.Documento == Documento)
                    .FirstOrDefault();
        }

        
        public string Actualizar()
        {
            tblCliente _cliente = dbAlquiler.tblClientes
                        .Where(p => p.Documento == cliente.Documento)
                        .FirstOrDefault();

            _cliente.TipoDocumento = cliente.TipoDocumento;
            _cliente.Nombres = cliente.Nombres;
            _cliente.Apellidos = cliente.Apellidos;
            _cliente.Edad = cliente.Edad;
            _cliente.NumeroLicencia = cliente.NumeroLicencia;
            _cliente.IDLicencia = cliente.IDLicencia;
            _cliente.Direccion = cliente.Direccion;

            dbAlquiler.SaveChanges();
            return "SE ACTUALIZARÓN LOS DATOS DEL CLIENTE";
        }

        public string Eliminar(string Documento)
        {
            tblCliente _cliente = dbAlquiler.tblClientes
                        .Where(p => p.Documento == Documento)
                        .FirstOrDefault();

            dbAlquiler.tblClientes.Remove(_cliente);
            dbAlquiler.SaveChanges();
            return "SE ELIMINÓ EL CLIENTE";
        }
    }
}