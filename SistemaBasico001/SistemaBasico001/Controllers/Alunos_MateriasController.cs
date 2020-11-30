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
    public class Alunos_MateriasController : Controller
    {
        private SistemaBasico001Entities db = new SistemaBasico001Entities();
        // POST: Alunos_Materias/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        public ActionResult Create()
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                ViewBag.Materia = new SelectList(db.materias, "IdMateria", "Nome");
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Aluno,Materia")] Alunos_Materias alunos_Materias)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                alunos_Materias.IDAluno = Convert.ToInt32(Session["IDAIU"]);
                if (ModelState.IsValid)
                {
                    db.Alunos_Materias.Add(alunos_Materias);
                    db.SaveChanges();
                    return RedirectToAction("Details", "alunos");
                }

                ViewBag.Materia = new SelectList(db.materias, "IdMateria", "Nome", alunos_Materias.IDMateria);
                return View(alunos_Materias);
            }
            else if (Convert.ToInt32(Session["NivelDeAcesso"]) == 2)
            {
                return RedirectToAction("Details", "professores");
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

        // GET: Alunos_Materias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Alunos_Materias alunos_Materias = db.Alunos_Materias.Find(id);
                if (alunos_Materias == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Aluno = new SelectList(db.alunos, "Matricula", "Nome", alunos_Materias.IDAluno);
                ViewBag.Materia = new SelectList(db.materias, "IdMateria", "Nome", alunos_Materias.IDMateria);
                return View(alunos_Materias);
            }
            else if (Convert.ToInt32(Session["NivelDeAcesso"]) == 2)
            {
                return RedirectToAction("Details", "professores");
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

        // POST: Alunos_Materias/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDAlunoMateria,Aluno,Materia")] Alunos_Materias alunos_Materias)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(alunos_Materias).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Datails", "alunos");
                }
                ViewBag.Aluno = new SelectList(db.alunos, "Matricula", "Nome", alunos_Materias.IDAluno);
                ViewBag.Materia = new SelectList(db.materias, "IdMateria", "Nome", alunos_Materias.IDMateria);
                return View(alunos_Materias);
            }
            else if (Convert.ToInt32(Session["NivelDeAcesso"]) == 2)
            {
                return RedirectToAction("Details", "professores");
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

        // GET: Alunos_Materias/Delete/5
        public ActionResult Delete(int? id)
        {
           
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Alunos_Materias alunos_Materias = db.Alunos_Materias.Find(id);
                if (alunos_Materias == null)
                {
                    return HttpNotFound();
                }
                return View(alunos_Materias);
            }
            else if (Convert.ToInt32(Session["NivelDeAcesso"]) == 2)
            {
                return RedirectToAction("Details", "professores");
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

        // POST: Alunos_Materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                Alunos_Materias alunos_Materias = db.Alunos_Materias.Find(id);
                db.Alunos_Materias.Remove(alunos_Materias);
                db.SaveChanges();
                return RedirectToAction("Details", "alunos");
            }
            else if (Convert.ToInt32(Session["NivelDeAcesso"]) == 2)
            {
                return RedirectToAction("Details", "professores");
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
