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
    public class Professores_TurmasController : Controller
    {
        private SistemaBasico001Entities db = new SistemaBasico001Entities();

        // GET: Professores_Turmas
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                var professores_Alunos = db.Professores_Alunos.Include(p => p.professores).Include(p => p.turmas);
                return View(professores_Alunos.ToList());
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

        // GET: Professores_Turmas/Details/5
        [HttpPost]
        public ActionResult Details(string Senha)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) >= 2)
            { 
                professores professor = db.professores.Find(Senha);
                if (Senha == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                if (professor == null)
                {
                    return HttpNotFound();
                }
                return View(professor);
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
        public ActionResult Details(professores professor)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) >= 2)
            {
                return View(professor);
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
        public ActionResult Detalhes()
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) >= 2)
            {
                professores professor = db.professores.Find(Convert.ToString(Session["id"]));
                if (Session["id"] == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                if (professor == null)
                {
                    return HttpNotFound();
                }
                return RedirectToAction("Details",professor);
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
        // GET: Professores_Turmas/Create
        public ActionResult Create()
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                ViewBag.IDTurma = new SelectList(db.turmas, "Numero", "Numero");
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

        // POST: Professores_Turmas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDProfessor,IDTurma")] Professores_Alunos professores_Alunos)
        {
            professores_Alunos.IDProfessor = Convert.ToString(Session["IDAIU"]);
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (ModelState.IsValid)
                {
                    db.Professores_Alunos.Add(professores_Alunos);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.IDTurma = new SelectList(db.turmas, "Numero", "ano", professores_Alunos.IDTurma);
                return View(professores_Alunos);
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

        // GET: Professores_Turmas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professores_Alunos professores_Alunos = db.Professores_Alunos.Find(id);
            if (professores_Alunos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDProfessor = new SelectList(db.professores, "Senha", "Nome", professores_Alunos.IDProfessor);
            ViewBag.IDTurma = new SelectList(db.turmas, "Numero", "ano", professores_Alunos.IDTurma);
            return View(professores_Alunos);
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

        // POST: Professores_Turmas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDProfessorTurma,IDProfessor,IDTurma")] Professores_Alunos professores_Alunos)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(professores_Alunos).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.IDProfessor = new SelectList(db.professores, "Senha", "Nome", professores_Alunos.IDProfessor);
                ViewBag.IDTurma = new SelectList(db.turmas, "Numero", "ano", professores_Alunos.IDTurma);
                return View(professores_Alunos);
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

        // GET: Professores_Turmas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Professores_Alunos professores_Alunos = db.Professores_Alunos.Find(id);
                if (professores_Alunos == null)
                {
                    return HttpNotFound();
                }
                return View(professores_Alunos);
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

        // POST: Professores_Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                Professores_Alunos professores_Alunos = db.Professores_Alunos.Find(id);
                db.Professores_Alunos.Remove(professores_Alunos);
                db.SaveChanges();
                return RedirectToAction("Details","Professores_Turmas");
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
