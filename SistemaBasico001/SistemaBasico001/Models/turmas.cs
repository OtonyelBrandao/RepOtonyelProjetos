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
    
    public partial class turmas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public turmas()
        {
            this.Alunos_Turmas = new HashSet<Alunos_Turmas>();
            this.Materia_Turmas = new HashSet<Materia_Turmas>();
            this.Professores_Turmas = new HashSet<Professores_Turmas>();
        }
    
        public int Numero { get; set; }
        public string ano { get; set; }
        public int IDTurma { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alunos_Turmas> Alunos_Turmas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Materia_Turmas> Materia_Turmas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Professores_Turmas> Professores_Turmas { get; set; }
    }
}
