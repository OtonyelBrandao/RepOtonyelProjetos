using System;

namespace SistemaBasico001.Models
{
    public class Aluno : Usuario
    {
        public Aluno AutenticarAluno(string Nome, string Senha)
        {
            SistemaBasico001Entities db = new SistemaBasico001Entities();
            Aluno aluno_ = new Aluno();
            alunos aluno = null;
            if (int.TryParse(Senha, out int i))
            {
                aluno = db.alunos.Find(Convert.ToInt32(Senha));
            }
            if (aluno != null)
            {
                if ((Nome == aluno.Nome && Senha == Convert.ToString(aluno.Matricula))
                    || Nome == aluno.Email && Senha == Convert.ToString(aluno.Matricula))
                {
                    aluno_.Nome = Nome;
                    aluno_.Senha = Senha;
                    aluno_.NA = 1;
                    aluno_.id = aluno.IDAluno;
                    return aluno_;
                }
                return null;
            }
            return null;
        }
    }
}