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
    using System;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    public partial class tblTipoVehiculo
    {
        public tblTipoVehiculo()
        {
            this.tblVehiculo = new HashSet<tblVehiculo>();
        }
    
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<tblVehiculo> tblVehiculo { get; set; }
    }
}
