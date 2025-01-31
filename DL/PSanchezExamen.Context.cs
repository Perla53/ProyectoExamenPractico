﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PSanchezExamenEntities : DbContext
    {
        public PSanchezExamenEntities()
            : base("name=PSanchezExamenEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CatEntidadFederativa> CatEntidadFederativa { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
    
        public virtual int EmpleadoDelete(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EmpleadoDelete", idParameter);
        }
    
        public virtual int EmpleadoAdd(string numeroNomina, string nombre, string apellidoPaterno, string apellidoMaterno, Nullable<int> idEstado)
        {
            var numeroNominaParameter = numeroNomina != null ?
                new ObjectParameter("NumeroNomina", numeroNomina) :
                new ObjectParameter("NumeroNomina", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var idEstadoParameter = idEstado.HasValue ?
                new ObjectParameter("IdEstado", idEstado) :
                new ObjectParameter("IdEstado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EmpleadoAdd", numeroNominaParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, idEstadoParameter);
        }
    
        public virtual ObjectResult<EmpleadoGetAll_Result> EmpleadoGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EmpleadoGetAll_Result>("EmpleadoGetAll");
        }
    
        public virtual ObjectResult<EmpleadoGetById_Result> EmpleadoGetById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EmpleadoGetById_Result>("EmpleadoGetById", idParameter);
        }
    
        public virtual int EmpleadoUpdate(Nullable<int> id, string numeroNomina, string nombre, string apellidoPaterno, string apellidoMaterno, Nullable<int> idEstado)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var numeroNominaParameter = numeroNomina != null ?
                new ObjectParameter("NumeroNomina", numeroNomina) :
                new ObjectParameter("NumeroNomina", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var idEstadoParameter = idEstado.HasValue ?
                new ObjectParameter("IdEstado", idEstado) :
                new ObjectParameter("IdEstado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EmpleadoUpdate", idParameter, numeroNominaParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, idEstadoParameter);
        }
    }
}
