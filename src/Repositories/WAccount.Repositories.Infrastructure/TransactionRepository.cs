using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WAccount.Domain.Models;
using WAccount.Repositories.Infrastructure.Interfaces;

namespace WAccount.Repositories.Infrastructure
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(DatabaseContext context) : base(context) { }

        public Transaction GetByUser(int userId)
        {
            return context.Set<Transaction>().FirstOrDefault(transaction => transaction.UserId == userId);
        }
    }
}
