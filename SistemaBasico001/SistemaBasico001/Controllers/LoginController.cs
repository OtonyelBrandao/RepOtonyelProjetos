using SistemaBasico001.Models;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace SistemaBasico001.Controllers
{
    public class LoginController : Controller
    {
        SistemaBasico001Entities db = new SistemaBasico001Entities();
        // GET: Login
        public ActionResult Login()
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                return RedirectToAction("Index", "alunos");
            }
            else if (Convert.ToInt32(Session["NivelDeAcesso"]) == 2)
            {
                return RedirectToAction("Details", "Professores_Turmas");
            }
            else if (Convert.ToInt32(Session["NivelDeAcesso"]) == 1)
            {
                return RedirectToAction("Details", "alunos");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Login(string Usuario, string Senha)
        {
            Usuario usuario = new Usuario();
            int Autenticar = usuario.AutenticarUsuario(Usuario, Senha);
            
                if (Autenticar == 1)
            {
                if (!(usuario.Ativo == -1 || usuario.Ativo == 0))
                {
                    Session["NivelDeAcesso"] = usuario.NA;
                    Session["Nome"] = usuario.Nome;
                    return RedirectToAction("Index", "alunos");
                }
                else
                {
                    ViewBag.Error = "alert alert-danger text-danger";
                    ViewBag.Message = "Usuario inativo !! ,por favor entre em contato com o administrador.";
                    return View();
                }
            }
            else if (Autenticar == 2)
            {
                if (!(usuario.Ativo == -1 || usuario.Ativo == 0))
                {
                    Session["NivelDeAcesso"] = usuario.NA;
                    Session["Nome"] = usuario.Nome;
                    Session["id"] = usuario.id;
                    alunos aluno = db.alunos.Find(Convert.ToInt32(usuario.id));
                    return RedirectToAction("Details", "alunos", aluno);
                }
                else
                {
                    ViewBag.Error = "alert alert-danger text-danger";
                    ViewBag.Message = "Usuario inativo !! ,por favor entre em contato com o administrador.";
                    return View();
                }
            }
            else if (Autenticar == 3)
            {
                if (!(usuario.Ativo == -1 || usuario.Ativo == 0))
                {
                    Session["NivelDeAcesso"] = usuario.NA;
                    Session["Nome"] = usuario.Nome;
                    Session["id"] = usuario.id;
                    professores professor = db.professores.Find(usuario.id);
                    return RedirectToAction("Details", "Professores_Turmas", professor);
                }
                else
                {
                    ViewBag.Error = "alert alert-danger text-danger";
                    ViewBag.Message = "Usuario inativo !! ,por favor entre em contato com o administrador.";
                    return View();
                }
            }
            else
            {
                ViewBag.Error = "alert alert-danger text-danger";
                ViewBag.Message = "Usuario ou Senha Invalido !!";
                return View();
            }
           
        }
        public ActionResult Deslogar()
        {
            if (Session == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                Session.Clear();
                return RedirectToAction("Login", "Login");
            }
        }
    }
}