namespace SistemaBasico001.Models
{
    public class Admin : Usuario
    {
        public Admin AutenticarAdmin(string Nome, string Senha)
        {
            Admin admin = new Admin();
            if (Nome == "Admin" && Senha == "123456" || Nome == "Admin.CCP@gmail.com" && Senha == "123456")
            {
                this.Nome = Nome;
                this.Senha = Senha;
                NA = 3;
                this.Ativo = 1;
                return admin;
            }
            else
            {
                return null;
            }
        }
    }
}