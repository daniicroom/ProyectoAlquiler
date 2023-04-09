using ServicioAlquiler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquiler.Class
{
    public class clsCliente
    {
        private DBAlquilerVehiculoEntities dbAlquiler = new DBAlquilerVehiculoEntities();
        public tblCliente cliente { get; set; }
        public tblCliente Consultar(string Documento)
        {
            return dbAlquiler.tblCliente
                    .Where(x => x.Documento == Documento)
                    .FirstOrDefault();
        }
        public string Grabarcliente()
        {
            dbAlquiler.tblCliente.Add(cliente);
            dbAlquiler.SaveChanges();
            return "Se ingresó el cliente" + cliente.Documento.ToString();
        }
        public string Actualizar()
        {
            tblCliente _cliente = dbAlquiler.tblCliente
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
            tblCliente _cliente = dbAlquiler.tblCliente
                        .Where(p => p.Documento == Documento)
                        .FirstOrDefault();

            dbAlquiler.tblCliente.Remove(_cliente);
            dbAlquiler.SaveChanges();
            return "Se eliminó el cliente";
        }
    }
}