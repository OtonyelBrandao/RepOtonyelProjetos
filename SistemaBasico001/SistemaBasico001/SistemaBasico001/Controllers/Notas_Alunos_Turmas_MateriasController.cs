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
    public class Notas_Alunos_Turmas_MateriasController : Controller
    {
        private SistemaBasico001Entities db = new SistemaBasico001Entities();

        // GET: Notas_Alunos_Turmas_Materias
        public ActionResult Index(string Nome ,int? Turma)
        {
            if(!String.IsNullOrEmpty(Nome))
            {
                if(Turma != null)
                {
                    return View(db.Alunos_Turmas.Where(n => n.alunos.Nome.ToUpper().Contains(Nome.ToUpper()) && n.turmas.Numero == Turma).ToList());
                }
                else
                {
                    return View(db.Alunos_Turmas.Where(n => n.alunos.Nome.ToUpper().Contains(Nome.ToUpper())).ToList());
                }
            }
            else if(Turma != null)
            {
                return View(db.Alunos_Turmas.Where(n => n.turmas.Numero == Turma).ToList());
            }
            return View(db.Alunos_Turmas.ToList());
            
        }
        //public ActionResult Index()
        //{
        //    return View(db.Alunos_Turmas.ToList());
        //}

        // GET: Notas_Alunos_Turmas_Materias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alunos aluno = db.alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // GET: Notas_Alunos_Turmas_Materias/Create
        public ActionResult Create()
        {
            ViewBag.IDAluno = new SelectList(db.alunos, "Matricula", "Nome");
            ViewBag.IDMateria = new SelectList(db.materias, "IdMateria", "Nome");
            ViewBag.IDNota = new SelectList(db.nota, "id", "Criador");
            ViewBag.IDTurma = new SelectList(db.turmas, "Numero", "ano");
            return View();
        }

        // POST: Notas_Alunos_Turmas_Materias/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDNotAlunoTurmaMateria,IDAluno,IDTurma,IDMateria,IDNota")] Notas_Alunos_Turmas_Materias notas_Alunos_Turmas_Materias)
        {
            if (ModelState.IsValid)
            {
                db.Notas_Alunos_Turmas_Materias.Add(notas_Alunos_Turmas_Materias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDAluno = new SelectList(db.alunos, "Matricula", "Nome", notas_Alunos_Turmas_Materias.IDAluno);
            ViewBag.IDMateria = new SelectList(db.materias, "IdMateria", "Nome", notas_Alunos_Turmas_Materias.IDMateria);
            ViewBag.IDNota = new SelectList(db.nota, "id", "Criador", notas_Alunos_Turmas_Materias.IDNota);
            ViewBag.IDTurma = new SelectList(db.turmas, "Numero", "ano", notas_Alunos_Turmas_Materias.IDTurma);
            return View(notas_Alunos_Turmas_Materias);
        }

        // GET: Notas_Alunos_Turmas_Materias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notas_Alunos_Turmas_Materias notas_Alunos_Turmas_Materias = db.Notas_Alunos_Turmas_Materias.Find(id);
            if (notas_Alunos_Turmas_Materias == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDAluno = new SelectList(db.alunos, "Matricula", "Nome", notas_Alunos_Turmas_Materias.IDAluno);
            ViewBag.IDMateria = new SelectList(db.materias, "IdMateria", "Nome", notas_Alunos_Turmas_Materias.IDMateria);
            ViewBag.IDNota = new SelectList(db.nota, "id", "Criador", notas_Alunos_Turmas_Materias.IDNota);
            ViewBag.IDTurma = new SelectList(db.turmas, "Numero", "ano", notas_Alunos_Turmas_Materias.IDTurma);
            return View(notas_Alunos_Turmas_Materias);
        }

        // POST: Notas_Alunos_Turmas_Materias/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDNotAlunoTurmaMateria,IDAluno,IDTurma,IDMateria,IDNota")] Notas_Alunos_Turmas_Materias notas_Alunos_Turmas_Materias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notas_Alunos_Turmas_Materias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDAluno = new SelectList(db.alunos, "Matricula", "Nome", notas_Alunos_Turmas_Materias.IDAluno);
            ViewBag.IDMateria = new SelectList(db.materias, "IdMateria", "Nome", notas_Alunos_Turmas_Materias.IDMateria);
            ViewBag.IDNota = new SelectList(db.nota, "id", "Criador", notas_Alunos_Turmas_Materias.IDNota);
            ViewBag.IDTurma = new SelectList(db.turmas, "Numero", "ano", notas_Alunos_Turmas_Materias.IDTurma);
            return View(notas_Alunos_Turmas_Materias);
        }

        // GET: Notas_Alunos_Turmas_Materias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notas_Alunos_Turmas_Materias notas_Alunos_Turmas_Materias = db.Notas_Alunos_Turmas_Materias.Find(id);
            if (notas_Alunos_Turmas_Materias == null)
            {
                return HttpNotFound();
            }
            return View(notas_Alunos_Turmas_Materias);
        }

        // POST: Notas_Alunos_Turmas_Materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Notas_Alunos_Turmas_Materias notas_Alunos_Turmas_Materias = db.Notas_Alunos_Turmas_Materias.Find(id);
            db.Notas_Alunos_Turmas_Materias.Remove(notas_Alunos_Turmas_Materias);
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
        public string GeneraToken()
        {
            var ran = new Random();
            return ran.Next().ToString();
        }
    }
}
