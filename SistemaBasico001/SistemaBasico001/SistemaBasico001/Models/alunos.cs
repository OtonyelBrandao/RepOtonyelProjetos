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
    
    public partial class alunos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public alunos()
        {
            this.Alunos_Materias = new HashSet<Alunos_Materias>();
            this.Alunos_Professores = new HashSet<Alunos_Professores>();
            this.Alunos_Turmas = new HashSet<Alunos_Turmas>();
            this.nota = new HashSet<nota>();
        }
    
        public string Nome { get; set; }
        public int Matricula { get; set; }
        public System.DateTime Nascimento { get; set; }
        public string Email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alunos_Materias> Alunos_Materias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alunos_Professores> Alunos_Professores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alunos_Turmas> Alunos_Turmas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nota> nota { get; set; }
    }
}
