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
    
    public partial class professores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public professores()
        {
            this.Alunos_Professores = new HashSet<Alunos_Professores>();
            this.Materias_Professores = new HashSet<Materias_Professores>();
            this.Professores_Alunos = new HashSet<Professores_Alunos>();
        }
    
        public string Nome { get; set; }
        public System.DateTime Nascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alunos_Professores> Alunos_Professores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Materias_Professores> Materias_Professores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Professores_Alunos> Professores_Alunos { get; set; }
    }
}
