
using System.Collections.Generic;
using WAccount.Domain.Models;

namespace WAccount.Repositories.Infrastructure.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
