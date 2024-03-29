//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServicioAlquiler.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    public partial class tblCliente
    {
        public tblCliente()
        {
            this.tblAlquilers = new HashSet<tblAlquiler>();
            this.tblReservars = new HashSet<tblReservar>();
            this.tblTelefonoClientes = new HashSet<tblTelefonoCliente>();
        }
    
        public string Documento { get; set; }
        public int TipoDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }
        public string NumeroLicencia { get; set; }
        public int IDLicencia { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<tblAlquiler> tblAlquilers { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual tblLicencia tblLicencia { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual tblTipoDocumento tblTipoDocumento { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<tblReservar> tblReservars { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<tblTelefonoCliente> tblTelefonoClientes { get; set; }
    }
}
