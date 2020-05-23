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
        private DbSet<T> entities;

        public Repository(DatabaseContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.ToList();
        }
        public IEnumerable<T> GetWhere(Expression <Func<T, bool>> wlambda)
        {
            return entities.Where(wlambda).ToList();
        }

        public IEnumerable<T> GetIncludedWhere(Expression<Func<T, object>> ilambda, Expression<Func<T, bool>> wlambda)
        {
            return entities.Include(ilambda).Where(wlambda).ToList();
        }

        public T GetById(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            T entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
            context.SaveChanges();
        }

    }
}
