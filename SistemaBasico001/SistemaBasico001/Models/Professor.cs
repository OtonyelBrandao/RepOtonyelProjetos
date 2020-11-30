using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaBasico001.Models
{
    public class Professor : Usuario
    {
        public Professor AutenticarProfessor(string Nome, string Senha)
        {
            Professor professor_ = new Professor();
            SistemaBasico001Entities db = new SistemaBasico001Entities();
            professores professor = db.professores.Find(Senha);
            if (professor != null)
            {
                if (Nome == professor.Nome && Senha == professor.Senha || Nome == professor.Email && Senha == professor.Senha)
                {
                    professor_.Nome = Nome;
                    professor_.Senha = Senha;
                    professor_.NA = 2;
                    professor_.id = professor.IDProfessor;
                    return professor_;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
                   
    }
}