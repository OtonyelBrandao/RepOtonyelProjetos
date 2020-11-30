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
        [HttpPost]
        public ActionResult Index(string Nome, int? Turma)
        {
            if (!String.IsNullOrEmpty(Nome))
            {
                if (Turma != null)
                {
                    return View(db.Alunos_Turmas.Where(n => n.alunos.Nome.ToUpper().Contains(Nome.ToUpper()) && n.turmas.Numero == Turma).ToList());
                }
                else
                {
                    return View(db.Alunos_Turmas.Where(n => n.alunos.Nome.ToUpper().Contains(Nome.ToUpper())).ToList());
                }
            }
            else if (Turma != null)
            {
                return View(db.Alunos_Turmas.Where(n => n.turmas.Numero == Turma).ToList());
            }
            return View(db.Alunos_Turmas.ToList());

        }
        public ActionResult Index()
        {

            return View(db.Alunos_Turmas.ToList());

        }
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
        // GET: notas/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(IQueryable<ListaDenotas> notas)
        {
            nota nt = new nota();
            foreach(var item in notas)
            {
                nt.Nota1 = item.nota;
                nt.IDMateria = item.IDMateria;
                nt.IDAluno = item.IDAluno;
                nt.IDTurma = item.IDTurma;
                nt.Criador = Convert.ToString(Session["Nome"]);
                nt.dataCreate = DateTime.Now.Date;
                //nt.dataCreate = DateTime.Now.Day;
                if (ModelState.IsValid)
                {
                    db.nota.Add(nt);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(nt);
            }
            return View(nt);
        }
        // POST: notas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nota1,dataCreate,dataUpdate,Criador,Atualizador")] nota nota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
