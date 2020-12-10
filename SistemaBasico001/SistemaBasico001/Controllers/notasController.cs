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
            if (Convert.ToInt32(Session["NivelDeAcesso"]) >= 1)
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
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // GET: notas/Details/5
        public ActionResult Details(int? id, int? idTurma)
        {//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
         //Seleção de Materias  Inicio >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            if (Convert.ToInt32(Session["NivelDeAcesso"]) >= 1)
            {
                IQueryable<Alunos_Materias> Alunos = db.Alunos_Materias.Where(AM => AM.IDAluno == id);
                IQueryable<Materia_Turmas> Turmas = db.Materia_Turmas.Where(MT => MT.idTurma == idTurma);
                IQueryable<Alunos_Materias> Materias = from T in Turmas
                                                       from A in Alunos
                                                       where T.idMateria == A.IDMateria
                                                       select (A);
                //Seleção de Materias  Fim >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //Seleção de Materias  Inicio >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                IQueryable<nota> nota1 = from nt in db.nota
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
                foreach (Alunos_Materias item in Materias)
                {
                    contador += 1;
                }
                string[,] notas = new string[contador, 13];
                ViewBag.IDTurma = idTurma;
                int contador2 = 0;
                int cont3 = 1;
                foreach (Alunos_Materias Materia in Materias)
                {
                    notas[contador2, 0] = Materia.materias.Nome;
                    notas[contador2, 1] = Convert.ToString(Materia.materias.IdMateria);
                    IQueryable<nota> Notas = nota1.Where(n => n.IDMateria == Materia.IDMateria);
                    cont3++;
                    foreach (nota Nota in Notas)
                    {
                        if (cont3 == 13)
                        {
                            notas[contador2, cont3] = Convert.ToString(
                                Convert.ToInt32(notas[contador2, 2]) +
                                Convert.ToInt32(notas[contador2, 4]) +
                                Convert.ToInt32(notas[contador2, 6]) +
                                Convert.ToInt32(notas[contador2, 8]) / 4);
                        }
                        else
                        {
                            if (Nota.IDMateria == Materia.materias.IdMateria)
                            {
                                notas[contador2, cont3] = Convert.ToString(Nota.Nota1);
                                notas[contador2, cont3+1] = Convert.ToString(Nota.id);
                            }
                            else
                            {
                                notas[contador2, cont3] = " ";
                            }

                        }
                        cont3 += 2;
                    }
                    cont3 = 1;
                    contador2 += 1;
                }

                ViewData["notas"] = notas;
                Notas Nts = new Notas();
                contador = -1;
                ViewBag.TabelaDeNotas = new List<Notas>();
                foreach (Alunos_Materias item in Materias)
                {
                    contador += 1;

                    ViewBag.TabelaDeNotas.Add(new Notas(
                        notas[contador, 0],
                        notas[contador, 1],
                        notas[contador, 2],
                        notas[contador, 3],
                        notas[contador, 4],
                        notas[contador, 5],
                        notas[contador, 6],
                        notas[contador, 7],
                        notas[contador, 8],
                        notas[contador, 9],
                        notas[contador, 10],
                        notas[contador, 11],
                        notas[contador, 12]
                        ));
                }
                //Varrendo Notas Nas Materias Fim >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
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
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }

        // GET: notas/Create
        public ActionResult Create()
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) >= 2)
            {
                ViewBag.IDAluno = new SelectList(db.alunos, "IDAluno", "Nome");
                ViewBag.IDMateria = new SelectList(db.materias, "IdMateria", "Nome");
                ViewBag.IDTurma = new SelectList(db.turmas, "IDTurma", "Numero");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // POST: notas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nota1,IDAluno,IDTurma,IDMateria")] nota nota)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) >= 2)
            {
                if (ModelState.IsValid)
                {
                    db.nota.Add(nota);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.IDAluno = new SelectList(db.alunos, "IDAluno", "Nome", nota.IDAluno);
                ViewBag.IDMateria = new SelectList(db.materias, "IdMateria", "Nome", nota.IDMateria);
                ViewBag.IDTurma = new SelectList(db.turmas, "IDTurma", "ano", nota.IDTurma);
                return View(nota);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
        public ActionResult Edit(string IDMateria ,string IDNota, int? IDAluno , int?IDTurma)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) >= 2)
            {
                alunos aluno = db.alunos.Find(IDAluno);
                turmas turma = db.turmas.Find(IDTurma);
                materias materia = db.materias.Find(Convert.ToInt32(IDMateria));
                nota nota;
                if (IDNota == "")
                    IDNota = "-1";
                else
                {
                    nota = db.nota.Find(Convert.ToInt32(IDNota));
                    ViewBag.Nota = nota;
                }

                ViewBag.Aluno = aluno;
                ViewBag.Materia = materia;
                ViewBag.Turma = turma;
                ViewBag.IDNota = Convert.ToInt32(IDNota);
                

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
        // POST: notas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(int? IDNota, float Nota , int IDAluno ,int IDTurma ,int IDMateria)
        {
            if (Convert.ToInt32(Session["NivelDeAcesso"]) >= 2)
            {
                if(IDNota > -1 )
                {
                    nota nota = db.nota.Find(IDNota);
                    nota.Nota1 = Nota;
                    if (ModelState.IsValid)
                    {
                        db.Entry(nota).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    return View(nota);
                }
                else if(IDNota == -1 || IDNota == null)
                {
                    nota nota = new nota();
                    nota.IDAluno = IDAluno;
                    nota.IDMateria = IDMateria;
                    nota.IDTurma = IDTurma;
                    nota.Nota1 = Nota;
                    db.nota.Add(nota);
                    db.SaveChanges();
                    return RedirectToAction("Index");


                }
                else 
                {
                    
                    nota nota = db.nota.Find(IDNota);
                    nota.Nota1 = Nota;
                    if (ModelState.IsValid)
                    {
                        db.Entry(nota).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    return View(nota);
                }
                
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
