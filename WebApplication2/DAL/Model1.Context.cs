﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class eTicaretDbEntities1 : DbContext
    {
        public eTicaretDbEntities1()
            : base("name=eTicaretDbEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<alisveriDetay> alisveriDetays { get; set; }
        public virtual DbSet<kartStatuTable> kartStatuTables { get; set; }
        public virtual DbSet<kartTable> kartTables { get; set; }
        public virtual DbSet<rolTable> rolTables { get; set; }
        public virtual DbSet<slideImageTable> slideImageTables { get; set; }
        public virtual DbSet<uyeRolu> uyeRolus { get; set; }
        public virtual DbSet<uyeTable> uyeTables { get; set; }
        public virtual DbSet<urunTable> urunTables { get; set; }
        public virtual DbSet<kategoriTable> kategoriTables { get; set; }
    }
}
