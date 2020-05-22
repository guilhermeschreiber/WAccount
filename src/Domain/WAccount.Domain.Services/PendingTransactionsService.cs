
using WAccount.Domain.Services.Interfaces;
using WAccount.Repositories.Infrastructure;

namespace WAccount.Domain.Services
{
    public class PendingTransactionsService : BaseService, IPendingTransactionsService
    {
        public PendingTransactionsService(DatabaseContext context) : base(context) { }
        public void ResolvePendingTransactions()
        {
            System.Console.WriteLine("PendingTransactionsService");
        }
    }
}
