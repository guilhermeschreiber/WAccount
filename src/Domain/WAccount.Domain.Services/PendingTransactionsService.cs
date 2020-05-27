using System;
using WAccount.Domain.Models.Enumerators;
using WAccount.Domain.Services.Interfaces;
using WAccount.Repositories.Infrastructure.Interfaces;

namespace WAccount.Domain.Services
{
    public class PendingTransactionsService : IPendingTransactionsService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserAccountRepository _userAccountRepository;

        public PendingTransactionsService (ITransactionRepository transactionRepository,
            IUserAccountRepository userAccountRepository) 
        {
            _transactionRepository = transactionRepository;
            _userAccountRepository = userAccountRepository;
        }

        public bool ResolvePendingTransactions()
        {
            var updated = false;

            var transactions = _transactionRepository
                .GetWhere(x => x.Result == TransactionResult.Pending && x.Scheduling.Date <= DateTime.Now.Date);

            foreach (var transaction in transactions)
            {
                var userAccount = _userAccountRepository.GetById(transaction.UserId);

                if (userAccount != null)
                {
                    if (transaction.Type == TransactionType.Credit)
                    {
                        userAccount.Balance += transaction.Amount;
                        transaction.Result = TransactionResult.Done;
                    }
                    else
                    {
                        if (userAccount.Balance > transaction.Amount)
                        {
                            userAccount.Balance -= transaction.Amount;
                            transaction.Result = TransactionResult.Done;
                        }
                        else
                        {
                            transaction.Result = TransactionResult.Error;
                        }
                    }
                    _userAccountRepository.Update(userAccount);
                }
                transaction.UpdatedAt = DateTime.Now;
                _transactionRepository.Update(transaction);
                updated = true;
            }

            return updated;
        }
    }
}
