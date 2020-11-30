using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaBasico001.Models
{
    public class Usuario
    {

        public int NA { get; set; }
        public int id { get; set; }
        public int Ativo { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }

        public int AutenticarUsuario(string Usuario , string Senha)
        {
            Admin admin = new Admin();
            Aluno aluno = new Aluno();
            Professor professor = new Professor();
            if (admin.AutenticarAdmin(Usuario, Senha) != null) {
                NA = admin.NA;
                Ativo = admin.Ativo;
                Nome = admin.Nome;
                Senha = admin.Senha;
                return 1;
            }
            else if (aluno.AutenticarAluno(Usuario, Senha) != null) {
                aluno = aluno.AutenticarAluno(Usuario, Senha);
                NA = aluno.NA;
                Ativo = aluno.Ativo;
                Nome = aluno.Nome;
                this.Senha = aluno.Senha;
                id = aluno.id;
                return 2;
            }
            else if (professor.AutenticarProfessor(Usuario, Senha) != null) {
                professor = professor.AutenticarProfessor(Usuario, Senha);
                NA = professor.NA;
                Ativo = professor.Ativo;
                Nome = professor.Nome;
                this.Senha = professor.Senha;
                return 3;
            }
            else
            {
                return 0;
            }
        }
    }
}