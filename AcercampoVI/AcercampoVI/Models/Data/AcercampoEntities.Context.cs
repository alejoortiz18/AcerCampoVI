﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AcercampoVI.Models.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ACERCAMPOVIEntities : DbContext
    {
        public ACERCAMPOVIEntities()
            : base("name=ACERCAMPOVIEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DetalleE> Detalle { get; set; }
        public virtual DbSet<FacturaE> Factura { get; set; }
        public virtual DbSet<ProductoE> Producto { get; set; }
        public virtual DbSet<RolE> Rol { get; set; }
        public virtual DbSet<RutaE> Ruta { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TipoProductoE> TipoProducto { get; set; }
        public virtual DbSet<TipoTransporteE> TipoTransporte { get; set; }
        public virtual DbSet<UsuariosE> Usuarios { get; set; }
        public virtual DbSet<UsuarioXRolE> UsuarioXRol { get; set; }
        public virtual DbSet<VehiculoE> Vehiculo { get; set; }
    }
}
