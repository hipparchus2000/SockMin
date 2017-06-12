using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Entities;
using Repository.Entities.BaseClasses;
using Repository.Entities.Html;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly SockMinDbContext _context;

        public Repository(SockMinDbContext context)
        {
            this._context = context;
        }

        public IQueryable<T> All
        {
            get { return _context.Set<T>(); }
        }

        IQueryable<T> IRepository<T>.All()
        {
            return All;
        }

        public T Find(Guid Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _context.Set<T>().Attach(entity);
            _context.Set<T>().Remove(entity);
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
