using SistemaBasico001.Models;
using SistemaBasico001.Repositorys;
using SistemaBasico001.Repositorys.BoletoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaBasico001.Controllers
{
    public class BoletoController : Controller
    {
        private IBoletoRepository boletoRepository;
        private IRepositoryCRUDBase<alunos> alunoRepository;
        private IRepositoryCRUDBase<materias> materiaRepository;
        public BoletoController()
        {
            this.boletoRepository = new BoletoRepository();
            this.alunoRepository = new RepositoryCRUDBase<alunos>();
            this.materiaRepository = new RepositoryCRUDBase<materias>();
        }
        // GET: Boleto
        public ActionResult Index(/*int IDAluno, int IDMateria*/)
        {
            int IDAluno = 1;
            int IDMateria = 1;

            var aluno = alunoRepository.Find(IDAluno);
            var materia = materiaRepository.Find(IDMateria);
            ViewBag.Matricula = aluno.Matricula;
            ViewBag.Nome = aluno.Nome;
            ViewBag.Curso = materia.Nome;
            //return View(boletoRepository.Filter(b => b.IDAluno == IDAluno && b.IDMateria == IDMateria));
            return View(boletoRepository.Get());
        }

        //// GET: Boleto/Details/5
        public ActionResult Details(int id)
        {
            return View(boletoRepository.Find(id));
        }
        [HttpPost]
        public ActionResult Details(string DataVencimento,DateTime DataPagamento,string Valor,int id,string TotalPagar,string Desconto,string Multa)
         {
            Boleto boleto = new Boleto();
            boleto = boletoRepository.Find(id);
            try
            {
                boleto.DataVencimento = Convert.ToDateTime(DataVencimento);
                boleto.DataPagamento = DataPagamento;
                boleto.Valor = Convert.ToDouble(Valor);
                boleto.ValorPago = Convert.ToDouble(TotalPagar.Replace("R$",""));
                boleto.Desconto = Convert.ToDouble(Desconto);
                boleto.Multa = Convert.ToDouble(Multa);
                boleto.Status = "p";
                boletoRepository.Update(boleto);
                boletoRepository.commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(boleto);
            }
        }
        // GET: Boleto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Boleto/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //// GET: Boleto/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: Boleto/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Boleto/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Boleto/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
