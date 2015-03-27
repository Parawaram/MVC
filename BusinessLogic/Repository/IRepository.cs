using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Remail.BusinessLogic.Repository
{
    public interface IRepository<T>
    {       
        T Get(Func<T, bool> predicate);
        T FirstOrDefault(Func<T, bool> predicate);
        IList<T> GetAll(Func<T, bool> predicate);
        IList<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        IQueryable<T> GetQueryable(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetQueryable();
        int Count(Func<T, bool> predicate);
        int Count();
    }
}
