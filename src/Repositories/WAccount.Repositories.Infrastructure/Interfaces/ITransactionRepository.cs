using System.Collections.Generic;
using WAccount.Domain.Models;

namespace WAccount.Repositories.Infrastructure.Interfaces
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        public IEnumerable<Transaction> GetByUser(int userId);
    }
}
