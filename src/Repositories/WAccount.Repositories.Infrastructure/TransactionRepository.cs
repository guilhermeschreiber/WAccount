using System.Collections.Generic;
using System.Linq;
using WAccount.Domain.Models;
using WAccount.Repositories.Infrastructure.Interfaces;

namespace WAccount.Repositories.Infrastructure
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(DatabaseContext context) : base(context) { }

        public IEnumerable<Transaction> GetByUser(int userId)
        {
            return context.Set<Transaction>().Where(transaction => transaction.UserId == userId).ToList();
        }
    }
}
