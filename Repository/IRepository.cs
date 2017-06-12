using System;
using System.Linq;

namespace Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> All();
        T Find(Guid id);
        void Delete(T entity);
        void Insert(T entity);
        void Update(T entity);

    }
}