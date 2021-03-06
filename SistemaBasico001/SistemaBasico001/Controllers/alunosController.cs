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
    public class alunosController : Controller
    {
        private SistemaBasico001Entities db = new SistemaBasico001Entities();

        // GET: alunos
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                return View(db.alunos.ToList());
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

        // GET: alunos/Details/5
        [HttpPost]
        public ActionResult Details(int? Matricula)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) >= 2)
            {
                if (Matricula == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                alunos alunos = db.alunos.Find(Matricula);
                if (alunos == null)
                {
                    return HttpNotFound();
                }
                return View(alunos);
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
        public ActionResult Details(alunos alunos)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 1)
            {
                if (alunos == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                if (alunos == null)
                {
                    return HttpNotFound();
                }
                return View(alunos);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            
        }
        public ActionResult Detalhes()
        {
                if (Convert.ToInt32(Session["NivelDeAcesso"]) == 1)
                {
                    alunos alunos = db.alunos.Find(Convert.ToInt32(Session["id"]));
                    if (Session["id"] == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    if (alunos == null)
                    {
                        return HttpNotFound();
                    }
                    return RedirectToAction("Details", alunos);
                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
        }
        // GET: alunos/Create
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

        // POST: alunos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Matricula,Nascimento,Email")] alunos alunos)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                alunos.Matricula = Convert.ToInt32(Convert.ToString(DateTime.Now.Year) + alunos.Matricula);
                if (ModelState.IsValid)
                {
                    db.alunos.Add(alunos);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(alunos);
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

        // GET: alunos/Edit/5
        [HttpPost]
        public ActionResult Edit(int? Matricula)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (Matricula == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                alunos alunos = db.alunos.Find(Matricula);
                if (alunos == null)
                {
                    return HttpNotFound();
                }
                return View(alunos);
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

        // POST: alunos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "Nome,Matricula,Nascimento,Email")] alunos alunos)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(alunos).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(alunos);
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

        // GET: alunos/Delete/5
        [HttpPost]
        public ActionResult Delete(int? Matricula)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                if (Matricula == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                alunos alunos = db.alunos.Find(Matricula);
                if (alunos == null)
                {
                    return HttpNotFound();
                }
                return View(alunos);
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

        // POST: alunos/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Matricula)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) == 3)
            {
                alunos alunos = db.alunos.Find(Matricula);
                db.alunos.Remove(alunos);
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
