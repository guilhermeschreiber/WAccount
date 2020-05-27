using System;
using WAccount.Domain.Services.Interfaces;
using WAccount.Repositories.Infrastructure.Interfaces;

namespace WAccount.Domain.Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public const double DAILY_RETURN_RATE = 0.0025;

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
                var diffDays = (int) (DateTime.Now - user.UpdatedAt).TotalDays;
                var actualBalance = user.Balance;
                user.Balance *= (decimal) Math.Pow(1 + DAILY_RETURN_RATE, diffDays);

                if (diffDays > DateTime.Now.Day)
                {
                    var lastMounthBalance = 
                        user.Balance / 
                        (decimal) Math.Pow(1 + DAILY_RETURN_RATE, DateTime.Now.Day);

                    user.MonthlyIncome = user.Balance - lastMounthBalance;
                }
                else
                {
                    user.MonthlyIncome += user.Balance - actualBalance;
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
