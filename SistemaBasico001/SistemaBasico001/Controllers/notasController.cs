using SistemaBasico001.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SistemaBasico001.Controllers
{
    public class notasController : Controller
    {
        private SistemaBasico001Entities db = new SistemaBasico001Entities();

        // GET: notas
        public ActionResult Index(int? turma, string nome)
        {
            List<Alunos_Turmas> alunos = db.Alunos_Turmas.ToList();
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
        public ActionResult Details(int? id, int idTurma)
        {//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            //Seleção de Materias  Inicio >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            var Alunos = db.Alunos_Materias.Where(AM => AM.IDAluno == id);
            var Turmas = db.Materia_Turmas.Where(MT => MT.idTurma == idTurma);
            var Materias = from T in Turmas
                           from A in Alunos
                           where T.idMateria == A.IDMateria
                           select (A);
            //Seleção de Materias  Fim >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //Seleção de Materias  Inicio >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            IQueryable <nota> nota1 = from nt in db.nota
                                     from al in db.alunos
                                     from tm in db.turmas
                                     from mt in db.materias
                                     where al.IDAluno == id
                                     && tm.IDTurma == idTurma
                                     && mt.IdMateria == nt.IDMateria
                                     && tm.IDTurma == nt.IDTurma
                                     && al.IDAluno == nt.IDAluno
                                     select (nt);
            //Seleção de Materias  Fim >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //Varrendo Notas Nas Materias Inicio >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            int contador = 0;
            foreach (var item in Materias)
            {
                contador += 1;
            }
            string[,] notas = new string[contador, 7];
            ViewBag.IDTurma = idTurma;
            int contador2 = 0;
            int cont3 = 1;
            foreach (var Materia in Materias)
            {
                notas[contador2, 0] = Materia.materias.Nome;
                var Notas = nota1.Where(n => n.IDMateria == Materia.IDMateria);
                foreach (nota Nota in Notas)
                {
                    if (cont3 == 6)
                    {
                        notas[contador2, cont3] = Convert.ToString(
                            Convert.ToInt32(notas[contador2, 1]) +
                            Convert.ToInt32(notas[contador2, 2]) +
                            Convert.ToInt32(notas[contador2, 3]) +
                            Convert.ToInt32(notas[contador2, 4]) / 4);
                    }
                    else
                    {
                        if (Nota.IDMateria == Materia.materias.IdMateria)
                        {
                            notas[contador2, cont3] = Convert.ToString(Nota.Nota1);
                        }
                        else
                        {
                            notas[contador2, cont3] = " ";
                        }

                    }
                    cont3++;
                }
                cont3 = 1;
                contador2 += 1;
            }
            
            ViewData["notas"] = notas;
            Notas Nts = new Notas();
            contador = -1;
            ViewBag.TabelaDeNotas = new List<Notas>();
            foreach (var item in Materias)
            {
                contador += 1;
                //Nts.Materia = notas[contador, 0];
                //Nts.Nota1 = notas[contador, 1];
                //Nts.Nota2 = notas[contador, 2];
                //Nts.Nota3 = notas[contador, 3];
                //Nts.Nota4 = notas[contador, 4];
                //Nts.Recu = notas[contador, 5];
                //Nts.Media = notas[contador, 6];
                ViewBag.TabelaDeNotas.Add( new Notas(
                    notas[contador, 0], 
                    notas[contador, 1],
                    notas[contador, 2],
                    notas[contador, 3],
                    notas[contador, 4],
                    notas[contador, 5],
                    notas[contador, 6]
                    ));
            }
            //Varrendo Notas Nas Materias Fim >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            // materia n1 n2 n3 n4 recu media
            // string  real real real real real real
            //                           n1+n2+n3+n4/4
            //                           n1+n2+n3+recu/4

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
