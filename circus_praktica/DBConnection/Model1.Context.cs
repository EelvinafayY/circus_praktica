﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace circus_praktica.DBConnection
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Circus_FayzullinaEntities : DbContext
    {
        public Circus_FayzullinaEntities()
            : base("name=Circus_FayzullinaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<Animal_trainer> Animal_trainer { get; set; }
        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<Cell> Cell { get; set; }
        public virtual DbSet<Concert_Shedule> Concert_Shedule { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Perfomance> Perfomance { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<Training_Schedule> Training_Schedule { get; set; }
    }
}