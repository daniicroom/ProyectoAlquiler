﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBAlquilerVehiculoEntities1 : DbContext
    {
        public DBAlquilerVehiculoEntities1()
            : base("name=DBAlquilerVehiculoEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tblAlquiler> tblAlquilers { get; set; }
        public DbSet<tblCargoEmpleado> tblCargoEmpleadoes { get; set; }
        public DbSet<tblCiudad> tblCiudads { get; set; }
        public DbSet<tblCliente> tblClientes { get; set; }
        public DbSet<tblColor> tblColors { get; set; }
        public DbSet<tblDepartamento> tblDepartamentoes { get; set; }
        public DbSet<tblDevolucion> tblDevolucions { get; set; }
        public DbSet<tblEmpleado> tblEmpleadoes { get; set; }
        public DbSet<tblGama> tblGamas { get; set; }
        public DbSet<tblLicencia> tblLicencias { get; set; }
        public DbSet<tblMarca> tblMarcas { get; set; }
        public DbSet<tblPai> tblPais { get; set; }
        public DbSet<tblSede> tblSedes { get; set; }
        public DbSet<tblTelefonoCliente> tblTelefonoClientes { get; set; }
        public DbSet<tblTipoDocumento> tblTipoDocumentoes { get; set; }
        public DbSet<tblTipoTelefono> tblTipoTelefonoes { get; set; }
        public DbSet<tblTipoVehiculo> tblTipoVehiculoes { get; set; }
        public DbSet<tblVehiculo> tblVehiculoes { get; set; }
    }
}