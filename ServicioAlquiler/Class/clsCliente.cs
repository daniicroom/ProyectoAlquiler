using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquiler.Class
{
    public class clsCliente
    {
        private DBAlquilerVehiculoEntities1 dbAlquiler = new DBAlquilerVehiculoEntities1();
        public tblCliente cliente { get; set; }
        public tblCliente Consultar(string Documento)
        {
            return dbAlquiler.tblClientes
                    .Where(x => x.Documento == Documento)
                    .FirstOrDefault();
        }
        public string Grabarcliente()
        {
            dbAlquiler.tblClientes.Add(cliente);
            dbAlquiler.SaveChanges();
            return "Se ingresó el cliente" + cliente.Documento.ToString();
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
            return "Se actualizó el cliente";
        }
        public string Eliminar(string Documento)
        {
            tblCliente _cliente = dbAlquiler.tblClientes
                        .Where(p => p.Documento == Documento)
                        .FirstOrDefault();

            dbAlquiler.tblClientes.Remove(_cliente);
            dbAlquiler.SaveChanges();
            return "Se eliminó el cliente";
        }
    }
}