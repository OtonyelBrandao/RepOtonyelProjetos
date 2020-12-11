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
            var pfs = db.professores.ToList();
            foreach (var pf in pfs)
            {
                if (Nome.Trim().ToUpper() == pf.Nome.Trim().ToUpper() && Senha.Trim().ToUpper() == pf.Senha.Trim().ToUpper() ||
                    Nome.Trim().ToUpper() == pf.Email.Trim().ToUpper() && Senha.Trim().ToUpper() == pf.Senha.Trim().ToUpper())
                {
                    professor_.Nome = Nome;
                    professor_.Senha = Senha;
                    professor_.NA = 2;
                    professor_.id = pf.IDProfessor;
                    professor_.Ativo = Convert.ToInt32(pf.Ativo);
                    return professor_;
                }
            }
            return null;
        }
                   
    }
}