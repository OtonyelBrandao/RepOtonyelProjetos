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
    public class turmasController : Controller
    {
        private SistemaBasico001Entities db = new SistemaBasico001Entities();

        // GET: turmas
        public ActionResult Index(int? turma)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {

                List<turmas> turmas = db.turmas.ToList();
                if (!(turma == null))
                {
                    return View(turmas.Where(t => t.Numero == turma));
                }
                else
                {
                    return View(turmas);
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

        // GET: turmas/Details/5
        public ActionResult Details(int? id)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) >= 1)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                turmas turmas = db.turmas.Find(id);
                Session["IDAIU"] = id;
                if (turmas == null)
                {
                    return HttpNotFound();
                }
                return View(turmas);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
           
        }

        // GET: turmas/Create
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

        // POST: turmas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Numero,ano")] turmas turmas)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (ModelState.IsValid)
                {
                    db.turmas.Add(turmas);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(turmas);
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

        // GET: turmas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                turmas turmas = db.turmas.Find(id);
                if (turmas == null)
                {
                    return HttpNotFound();
                }
                return View(turmas);
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

        // POST: turmas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Numero,ano,IDTurma")] turmas turmas)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(turmas).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(turmas);
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

        // GET: turmas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                turmas turmas = db.turmas.Find(id);
                if (turmas == null)
                {
                    return HttpNotFound();
                }
                return View(turmas);
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

        // POST: turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                IQueryable<Alunos_Turmas> AT = db.Alunos_Turmas.Where(at => at.IDTurma == id);
                IQueryable<Materia_Turmas> MT = db.Materia_Turmas.Where(mt => mt.idTurma == id);
                IQueryable<Professores_Turmas> PT = db.Professores_Turmas.Where(pt => pt.IDTurma == id);
                IQueryable<nota> nt = db.nota.Where(NT => NT.IDTurma == id);
                foreach (var pt in PT)
                {
                    db.Professores_Turmas.Remove(pt);
                }
                foreach (var mt in MT)
                {
                    db.Materia_Turmas.Remove(mt);
                }
                foreach (var at in AT)
                {
                    db.Alunos_Turmas.Remove(at);
                }
                foreach (var NT in nt)
                {
                    db.nota.Remove(NT);
                }
                turmas turmas = db.turmas.Find(id);
                db.turmas.Remove(turmas);
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
