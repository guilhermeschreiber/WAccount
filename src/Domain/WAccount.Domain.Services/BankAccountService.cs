using System;
using System.Linq;
using WAccount.Domain.Models;
using WAccount.Domain.Models.Enumerators;
using WAccount.Domain.Services.Interfaces;
using WAccount.Repositories.Infrastructure;
using WAccount.Repositories.Infrastructure.Interfaces;

namespace WAccount.Domain.Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public const decimal DAILY_RETURN_RATE = (decimal)(0.029 / 12);

        public BankAccountService (IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public bool UpdateBalanceDaily ()
        {
            var updated = false;

            foreach (var user in _userAccountRepository
                .GetWhere(x => DateTime.Now.Date > x.UpdatedAt.Date))
            {
                while (DateTime.Now.Date > user.UpdatedAt.Date)
                {
                    user.UpdatedAt = user.UpdatedAt.AddDays(1);
                    if (user.UpdatedAt.Day == 1)
                    {
                        user.MonthlyIncome = 0;
                    }
                    decimal dailyIncode = user.Balance * DAILY_RETURN_RATE;
                    user.MonthlyIncome += dailyIncode;
                    user.Balance += dailyIncode;
                }
                user.Balance = Decimal.Round(user.Balance, 2);
                user.MonthlyIncome = Decimal.Round(user.MonthlyIncome, 2);

                user.UpdatedAt = DateTime.Now;
                _userAccountRepository.Update(user);
                
                updated = true;
            }
            return updated;
        }
    }
}
