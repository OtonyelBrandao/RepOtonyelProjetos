using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaBasico001.Models;

namespace SistemaBasico001.Controllers
{
    public class professoresController : Controller
    {
        private SistemaBasico001Entities db = new SistemaBasico001Entities();

        // GET: professores
        public ActionResult Index(string Professor)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                ViewBag.ColunaInativa = "bg-danger";
                List<professores> professores = db.professores.ToList();
                if (!(Professor == null || Professor == ""))
                {
                    return View(professores.Where(p => p.Nome.Contains(Professor)));
                }
                else
                {
                    return View(professores);
                }
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
                return RedirectToAction("Login", "Login");
            }
        }

        // GET: professores/Details/5
        [HttpPost]
        public ActionResult Details(string Senha)
        {
            return RedirectToAction("Details", "Professores_Turmas", Senha);
            
        }

        // GET: professores/Create
        public ActionResult Create()
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                return View();
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
                return RedirectToAction("Login", "Login");
            }
        }

        // POST: professores/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Nascimento,Email,Senha")] professores professores)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (ModelState.IsValid)
                {
                    db.professores.Add(professores);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(professores);
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
                return RedirectToAction("Login", "Login");
            }
           
        }

        // GET: professores/Edit/5
        [HttpPost]
        public ActionResult Edit(string Senha)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (Senha == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                professores professores = db.professores.Find(Senha);
                if (professores == null)
                {
                    return HttpNotFound();
                }
                return View(professores);
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
                return RedirectToAction("Login", "Login");
            }
            
        }

        // POST: professores/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "Nome,Nascimento,Email,Senha")] professores professores)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(professores).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(professores);
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
                return RedirectToAction("Login", "Login");
            }
            
        }

        // GET: professores/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                professores professores = db.professores.Find(id);
                if (professores == null)
                {
                    return HttpNotFound();
                }
                return View(professores);
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
                return RedirectToAction("Login", "Login");
            }
           
        }

        // POST: professores/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                professores professores = db.professores.Find(id);
                if (professores.Ativo == null)
                {
                    professores.Ativo = 1;
                }
                else if(professores.Ativo == 1)
                {
                    professores.Ativo = -1;
                }
                else
                {
                    professores.Ativo = 1;
                }
                db.Entry(professores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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
                return RedirectToAction("Login", "Login");
            }  
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
