﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GalericiEntities3 : DbContext
    {
        public GalericiEntities3()
            : base("name=GalericiEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Araclar> Araclars { get; set; }
        public DbSet<kullanıcılar> kullanıcılar { get; set; }
        public DbSet<Musteriler> Musterilers { get; set; }
        public DbSet<Subeler> Subelers { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
