using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WAccount.Domain.Services;
using WAccount.Domain.Services.Interfaces;

namespace WAccount.BackgroundServices.MainService
{
    public class CurrentAccountBackgroundService : BackgroundService
    {
        private readonly ILogger<CurrentAccountBackgroundService> _logger;
        private IBankAccountService _bankAccountService;

        public CurrentAccountBackgroundService(
            ILogger<CurrentAccountBackgroundService> logger,
            IBankAccountService bankAccountService)
        {
            _logger = logger;
            _bankAccountService = bankAccountService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("CurrentAccountBackgroundService running at: {time}", DateTimeOffset.Now);
                await Task.Delay(2000, stoppingToken);
                _bankAccountService.UpdateBalance(null);
            }
        }
    }
}
