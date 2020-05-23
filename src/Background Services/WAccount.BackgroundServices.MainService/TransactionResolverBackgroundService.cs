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
            TimeSpan interval = new TimeSpan(0, 0, 5); // 30 seconds

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(interval, stoppingToken);
                if (_pendingTransactionsService.ResolvePendingTransactions())
                {
                    _logger.LogInformation("TransactionResolverBackgroundService running at: {time}", DateTimeOffset.Now);
                }
            }
        }
    }
}
