using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WAccount.Domain.Models;

namespace WAccount.Repositories.Infrastructure.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetWhere(Expression<Func<T, bool>> wlambda);
        public IEnumerable<T> GetIncludedWhere(Expression<Func<T, object>> ilambda, Expression<Func<T, bool>> wlambda);
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
