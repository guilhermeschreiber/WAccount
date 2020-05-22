using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WAccount.Domain.Services.Interfaces;

namespace WAccount.BackgroundServices.MainService
{
    public class TransactionResolverBackgroundService : BackgroundService
    {
        private readonly ILogger<TransactionResolverBackgroundService> _logger;
        private readonly IPendingTransactionsService _pendingTransactionsService;

        public TransactionResolverBackgroundService(
            ILogger<TransactionResolverBackgroundService> logger,
            IPendingTransactionsService pendingTransactionsService)
        {
            _logger = logger;
            _pendingTransactionsService = pendingTransactionsService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("TransactionResolverBackgroundService running at: {time}", DateTimeOffset.Now);
                await Task.Delay(2000, stoppingToken);
                _pendingTransactionsService.ResolvePendingTransactions();
            }
        }
    }
}
