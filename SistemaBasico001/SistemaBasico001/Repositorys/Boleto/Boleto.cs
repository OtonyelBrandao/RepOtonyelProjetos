using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using SistemaBasico001.Models;

namespace SistemaBasico001.Repositorys.BoletoRepo
{
    public interface IBoletoRepository  : IRepositoryCRUDBase<Boleto>
    {
        void commite();
    }
    public class BoletoRepository : RepositoryCRUDBase<Boleto>,IBoletoRepository , IDisposable 
    {
        private SistemaBasico001Entities db = new SistemaBasico001Entities();
        public void commite()
        {
            db.SaveChanges();
        }
    }
}