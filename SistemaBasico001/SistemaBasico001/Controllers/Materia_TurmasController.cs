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
    public class Materia_TurmasController : Controller
    {
        private SistemaBasico001Entities db = new SistemaBasico001Entities();

        
        // GET: Materia_Turmas/Create
        public ActionResult Create(int? IDTurma)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                ViewBag.idMateria = new SelectList(db.materias, "IdMateria", "Nome");
                ViewBag.idTurma = IDTurma;
                return View();
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

        // POST: Materia_Turmas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMateriaTurma,idTurma,idMateria")] Materia_Turmas materia_Turmas)
        {
            if (ModelState.IsValid)
            {
                db.Materia_Turmas.Add(materia_Turmas);
                db.SaveChanges();
                return RedirectToAction("Details","turmas",new { id = materia_Turmas.idTurma});
            }

            ViewBag.idMateria = new SelectList(db.materias, "IdMateria", "Nome", materia_Turmas.idMateria);
            ViewBag.idTurma = new SelectList(db.turmas, "IDTurma", "ano", materia_Turmas.idTurma);
            return View(materia_Turmas);
        }
        // GET: Materia_Turmas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Materia_Turmas materia_Turmas = db.Materia_Turmas.Find(id);
                if (materia_Turmas == null)
                {
                    return HttpNotFound();
                }
                return View(materia_Turmas);
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

        // POST: Materia_Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Materia_Turmas materia_Turmas = db.Materia_Turmas.Find(id);
            db.Materia_Turmas.Remove(materia_Turmas);
            db.SaveChanges();
            return RedirectToAction("Details", "turmas", new { id = materia_Turmas.idTurma });
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
