using SistemaBasico001.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SistemaBasico001.Repositorys
{
    public interface IRepositoryCRUDBase<T> where T : class
    {
        List<T> Get();
        T Find(object id);
        List<T> Filter(Func<T, bool> predicate);
        void Create(T Entity);
        void Update(T Entity);
        void commit();
    }
    public class RepositoryCRUDBase<T> : IRepositoryCRUDBase<T>, IDisposable where T : class
    {
        private SistemaBasico001Entities db = new SistemaBasico001Entities();
        public void commit()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public List<T> Filter(Func<T, bool> predicate)
        {
            return db.Set<T>().Where(predicate).ToList();
        }
        public T Find(object id)
        {
            return db.Set<T>().Find(id);
        }
        public List<T> Get()
        {
            return db.Set<T>().ToList();
        }
        public void Create(T Entity)
        {
            db.Set<T>().Add(Entity);
        }
        public void Update(T Entity)
        {
            db.Entry(Entity).State = EntityState.Modified;
        }
    }
}