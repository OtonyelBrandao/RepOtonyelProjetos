//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class nota
    {
        public int id { get; set; }
        public float Nota1 { get; set; }
        public Nullable<System.DateTime> dataCreate { get; set; }
        public Nullable<System.DateTime> dataUpdate { get; set; }
        public string Criador { get; set; }
        public string Atualizador { get; set; }
        public int IDAluno { get; set; }
        public int IDTurma { get; set; }
        public int IDMateria { get; set; }
    
        public virtual alunos alunos { get; set; }
        public virtual materias materias { get; set; }
        public virtual turmas turmas { get; set; }
    }
}
