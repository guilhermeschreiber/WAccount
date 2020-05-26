using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WAccount.Domain.Models;

namespace WAccount.Repositories.Infrastructure.Interfaces
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        public IEnumerable<Transaction> GetByUser(int userId);
    }
}
