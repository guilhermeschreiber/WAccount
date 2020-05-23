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
            TimeSpan interval = new TimeSpan(0, 10, 0); // 10 minutes

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(interval, stoppingToken);
                _bankAccountService.UpdateBalanceDaily();
            }
        }
    }
}
