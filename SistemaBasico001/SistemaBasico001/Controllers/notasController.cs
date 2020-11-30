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
    public class notasController : Controller
    {
        private SistemaBasico001Entities db = new SistemaBasico001Entities();

        // GET: notas
        public ActionResult Index(int? turma , string nome)
        {
            var alunos = db.Alunos_Turmas.ToList();
            if (!(turma == null || nome == null))
            {
                return View(alunos.Where(a => a.IDTurma == turma || a.alunos.Nome == nome));
            }
            else
            {
                return View(alunos);
            }
        }

        // GET: notas/Details/5
        public ActionResult Details(int? id,int idTurma)
        {
            ViewBag.IDTurma = idTurma;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var  aluno = db.alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // GET: notas/Create
        public ActionResult Create()
        {
            ViewBag.IDAluno = new SelectList(db.alunos, "IDAluno", "Nome");
            ViewBag.IDMateria = new SelectList(db.materias, "IdMateria", "Nome");
            ViewBag.IDTurma = new SelectList(db.turmas, "IDTurma", "Numero");
            return View();
        }

        // POST: notas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nota1,IDAluno,IDTurma,IDMateria")] nota nota)
        {
            if (ModelState.IsValid)
            {
                db.nota.Add(nota);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDAluno = new SelectList(db.alunos, "Matricula", "Nome", nota.IDAluno);
            ViewBag.IDMateria = new SelectList(db.materias, "IdMateria", "Nome", nota.IDMateria);
            ViewBag.IDTurma = new SelectList(db.turmas, "Numero", "ano", nota.IDTurma);
            return View(nota);
        }

        // GET: notas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nota nota = db.nota.Find(id);
            if (nota == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDAluno = new SelectList(db.alunos, "Matricula", "Nome", nota.IDAluno);
            ViewBag.IDMateria = new SelectList(db.materias, "IdMateria", "Nome", nota.IDMateria);
            ViewBag.IDTurma = new SelectList(db.turmas, "Numero", "ano", nota.IDTurma);
            return View(nota);
        }

        // POST: notas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nota1,dataCreate,dataUpdate,Criador,Atualizador,IDAluno,IDTurma,IDMateria")] nota nota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDAluno = new SelectList(db.alunos, "Matricula", "Nome", nota.IDAluno);
            ViewBag.IDMateria = new SelectList(db.materias, "IdMateria", "Nome", nota.IDMateria);
            ViewBag.IDTurma = new SelectList(db.turmas, "Numero", "ano", nota.IDTurma);
            return View(nota);
        }

        // GET: notas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nota nota = db.nota.Find(id);
            if (nota == null)
            {
                return HttpNotFound();
            }
            return View(nota);
        }

        // POST: notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            nota nota = db.nota.Find(id);
            db.nota.Remove(nota);
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
