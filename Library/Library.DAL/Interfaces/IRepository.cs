using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Library.DAL.Entities;

namespace Library.DAL.Interfaces
{
    public interface IRepository<T> where T: EntityBase
    {
        Task<T> GetById(int id);
        Task<List<T>> List();
        Task<List<T>> List(Expression<Func<T, bool>> predicate);
        Task<int> Insert(T entity);
        Task Delete(T entity);
        Task Update(T entity);
    }
}
