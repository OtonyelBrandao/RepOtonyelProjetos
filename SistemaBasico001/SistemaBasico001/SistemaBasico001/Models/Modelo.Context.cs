﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaBasico001.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SistemaBasico001Entities : DbContext
    {
        public SistemaBasico001Entities()
            : base("name=SistemaBasico001Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<alunos> alunos { get; set; }
        public virtual DbSet<Alunos_Materias> Alunos_Materias { get; set; }
        public virtual DbSet<Alunos_Professores> Alunos_Professores { get; set; }
        public virtual DbSet<Alunos_Turmas> Alunos_Turmas { get; set; }
        public virtual DbSet<Materia_Turmas> Materia_Turmas { get; set; }
        public virtual DbSet<materias> materias { get; set; }
        public virtual DbSet<Materias_Professores> Materias_Professores { get; set; }
        public virtual DbSet<nota> nota { get; set; }
        public virtual DbSet<professores> professores { get; set; }
        public virtual DbSet<Professores_Alunos> Professores_Alunos { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<turmas> turmas { get; set; }
    }
}
