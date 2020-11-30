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
    public class Alunos_ProfessoresController : Controller
    {
        private SistemaBasico001Entities db = new SistemaBasico001Entities();
        // GET: Alunos_Professores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alunos_Professores alunos_Professores = db.Alunos_Professores.Find(id);
            if (alunos_Professores == null)
            {
                return HttpNotFound();
            }
            return View(alunos_Professores);
        }

        // GET: Alunos_Professores/Create
        public ActionResult Create()
        {
            ViewBag.IDAluno = new SelectList(db.alunos, "Matricula", "Nome");
            ViewBag.IDProfessor = new SelectList(db.professores, "Senha", "Nome");
            return View();
        }

        // POST: Alunos_Professores/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDFKAlunosProfessores,IDAluno,IDProfessor")] Alunos_Professores alunos_Professores)
        {
            if (ModelState.IsValid)
            {
                db.Alunos_Professores.Add(alunos_Professores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDAluno = new SelectList(db.alunos, "Matricula", "Nome", alunos_Professores.IDAluno);
            ViewBag.IDProfessor = new SelectList(db.professores, "Senha", "Nome", alunos_Professores.IDProfessor);
            return View(alunos_Professores);
        }

        // GET: Alunos_Professores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alunos_Professores alunos_Professores = db.Alunos_Professores.Find(id);
            if (alunos_Professores == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDAluno = new SelectList(db.alunos, "Matricula", "Nome", alunos_Professores.IDAluno);
            ViewBag.IDProfessor = new SelectList(db.professores, "Senha", "Nome", alunos_Professores.IDProfessor);
            return View(alunos_Professores);
        }

        // POST: Alunos_Professores/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDFKAlunosProfessores,IDAluno,IDProfessor")] Alunos_Professores alunos_Professores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alunos_Professores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDAluno = new SelectList(db.alunos, "Matricula", "Nome", alunos_Professores.IDAluno);
            ViewBag.IDProfessor = new SelectList(db.professores, "Senha", "Nome", alunos_Professores.IDProfessor);
            return View(alunos_Professores);
        }

        // GET: Alunos_Professores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alunos_Professores alunos_Professores = db.Alunos_Professores.Find(id);
            if (alunos_Professores == null)
            {
                return HttpNotFound();
            }
            return View(alunos_Professores);
        }

        // POST: Alunos_Professores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alunos_Professores alunos_Professores = db.Alunos_Professores.Find(id);
            db.Alunos_Professores.Remove(alunos_Professores);
            db.SaveChanges();
            return RedirectToAction("Index");
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
