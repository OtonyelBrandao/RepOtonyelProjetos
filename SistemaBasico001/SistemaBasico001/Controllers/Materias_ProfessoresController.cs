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
    public class Materias_ProfessoresController : Controller
    {
        private SistemaBasico001Entities db = new SistemaBasico001Entities();
        // GET: Materias_Professores/Create
        public ActionResult Create()
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                ViewBag.IDMateria = new SelectList(db.materias, "IdMateria", "Nome");
                ViewBag.IDProfessor = new SelectList(db.professores, "Senha", "Nome");
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

        // POST: Materias_Professores/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDMateria,IDProfessor")] Materias_Professores materias_Professores)
        {
            materias_Professores.IDProfessor = Convert.ToInt32(Session["IDAIU"]);
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (ModelState.IsValid)
                {
                    db.Materias_Professores.Add(materias_Professores);
                    db.SaveChanges();
                    return RedirectToAction("Details","Professores_Turmas");
                }

                ViewBag.IDMateria = new SelectList(db.materias, "IdMateria", "Nome", materias_Professores.IDMateria);
                ViewBag.IDProfessor = new SelectList(db.professores, "Senha", "Nome", materias_Professores.IDProfessor);
                return View(materias_Professores);
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

        // GET: Materias_Professores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Materias_Professores materias_Professores = db.Materias_Professores.Find(id);
                if (materias_Professores == null)
                {
                    return HttpNotFound();
                }
                ViewBag.IDMateria = new SelectList(db.materias, "IdMateria", "Nome", materias_Professores.IDMateria);
                ViewBag.IDProfessor = new SelectList(db.professores, "Senha", "Nome", materias_Professores.IDProfessor);
                return View(materias_Professores);
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

        // POST: Materias_Professores/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDMateriaProfessor,IDMateria,IDProfessor")] Materias_Professores materias_Professores)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(materias_Professores).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.IDMateria = new SelectList(db.materias, "IdMateria", "Nome", materias_Professores.IDMateria);
                ViewBag.IDProfessor = new SelectList(db.professores, "Senha", "Nome", materias_Professores.IDProfessor);
                return View(materias_Professores);
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

        // GET: Materias_Professores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Materias_Professores materias_Professores = db.Materias_Professores.Find(id);
                if (materias_Professores == null)
                {
                    return HttpNotFound();
                }
                return View(materias_Professores);
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

        // POST: Materias_Professores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                Materias_Professores materias_Professores = db.Materias_Professores.Find(id);
                db.Materias_Professores.Remove(materias_Professores);
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
