﻿using System;
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
    public class Alunos_TurmasController : Controller
    {
        private SistemaBasico001Entities db = new SistemaBasico001Entities();
        // GET: Alunos_Turmas/Create
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

        // POST: Alunos_Turmas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDAlunos,IDTurma")] Alunos_Turmas alunos_Turmas)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                alunos_Turmas.IDAlunos = Convert.ToInt32(Session["IDAIU"]);
                if (ModelState.IsValid)
                {
                    db.Alunos_Turmas.Add(alunos_Turmas);
                    db.SaveChanges();
                    return RedirectToAction("Details", "alunos");
                }
                ViewBag.IDTurma = new SelectList(db.turmas, "Numero", "Numero", alunos_Turmas.IDTurma);
                return View(alunos_Turmas);
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

        // GET: Alunos_Turmas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Alunos_Turmas alunos_Turmas = db.Alunos_Turmas.Find(id);
                if (alunos_Turmas == null)
                {
                    return HttpNotFound();
                }
                ViewBag.IDAlunos = new SelectList(db.alunos, "Matricula", "Nome", alunos_Turmas.IDAlunos);
                ViewBag.IDTurma = new SelectList(db.turmas, "Numero", "Numero", alunos_Turmas.IDTurma);
                return View(alunos_Turmas);
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

        // POST: Alunos_Turmas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDAlunoTurma,IDAlunos,IDTurma")] Alunos_Turmas alunos_Turmas)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(alunos_Turmas).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.IDAlunos = new SelectList(db.alunos, "Matricula", "Nome", alunos_Turmas.IDAlunos);
                ViewBag.IDTurma = new SelectList(db.turmas, "Numero", "Numero", alunos_Turmas.IDTurma);
                return View(alunos_Turmas);
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

        // GET: Alunos_Turmas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Alunos_Turmas alunos_Turmas = db.Alunos_Turmas.Find(id);
                if (alunos_Turmas == null)
                {
                    return HttpNotFound();
                }
                return View(alunos_Turmas);
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

        // POST: Alunos_Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alunos_Turmas alunos_Turmas = db.Alunos_Turmas.Find(id);
            db.Alunos_Turmas.Remove(alunos_Turmas);
            db.SaveChanges();
            return RedirectToAction("Details","alunos");
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
