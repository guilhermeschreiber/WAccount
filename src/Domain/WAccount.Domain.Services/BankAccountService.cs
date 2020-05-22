using System;
using WAccount.Domain.Models;
using WAccount.Domain.Services.Interfaces;
using WAccount.Repositories.Infrastructure;

namespace WAccount.Domain.Services
{
    public class BankAccountService : BaseService, IBankAccountService
    {
        public BankAccountService(DatabaseContext context) : base (context) { }

        public void UpdateBalance (User user)
        {
            Console.WriteLine("UpdateBalance");
        }
    }
}
