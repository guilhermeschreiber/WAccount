using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WAccount.Domain.Models;
using WAccount.Repositories.Infrastructure.Interfaces;

namespace WAccount.Repositories.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DatabaseContext context;

        public Repository(DatabaseContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public IEnumerable<T> GetWhere(Expression <Func<T, bool>> wlambda)
        {
            return context.Set<T>().Where(wlambda).ToList();
        }

        public IEnumerable<T> GetIncludedWhere(Expression<Func<T, object>> ilambda, Expression<Func<T, bool>> wlambda)
        {
            return context.Set<T>().Include(ilambda).Where(wlambda).ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = context.Set<T>().SingleOrDefault(s => s.Id == id);

            if (entity == null) throw new ArgumentNullException("entity");

            var entry = context.Attach<T>(entity);
            entry.State = EntityState.Deleted;
            context.SaveChanges();
        }

    }
}
