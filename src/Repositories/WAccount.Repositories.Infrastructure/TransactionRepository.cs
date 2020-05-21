using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WAccount.Domain.Models;
using WAccount.Repositories.Infrastructure.Interfaces;

namespace WAccount.Repositories.Infrastructure
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(DatabaseContext context) : base(context) { }

        public Task<Transaction> GetByUser(int userId)
        {
            return context.Set<Transaction>().
                FirstOrDefaultAsync(transaction => transaction.UserId == userId);
        }
    }
}
