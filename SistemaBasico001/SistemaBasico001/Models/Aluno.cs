using System;

namespace SistemaBasico001.Models
{
    public class Aluno : Usuario
    {
        SistemaBasico001Entities db = new SistemaBasico001Entities();
        public Aluno AutenticarAluno(string Nome, string Senha)
        {
            Aluno aluno_ = new Aluno();
            var als = db.alunos;
            
            if (int.TryParse(Senha, out int i))
            {
                foreach (var al in als)
                {
                    if ((Nome.Trim().ToUpper() == al.Nome.Trim().ToUpper() && Senha.Trim().ToUpper() == Convert.ToString(al.Matricula).Trim().ToUpper())
                        || Nome.Trim().ToUpper() == al.Email.Trim().ToUpper() && Senha.Trim().ToUpper() == Convert.ToString(al.Matricula).Trim().ToUpper())
                    {
                        aluno_.Nome = Nome;
                        aluno_.Senha = Senha;
                        aluno_.NA = 1;
                        aluno_.id = al.IDAluno;
                        aluno_.Ativo = Convert.ToInt32(al.Ativo);
                        return aluno_;
                    }
                } 
            }
            return null;
        }
    }
}