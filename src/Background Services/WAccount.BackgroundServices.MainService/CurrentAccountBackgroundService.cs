using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
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
            TimeSpan interval = new TimeSpan(hours: 0, minutes: 0, seconds: 50);

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(interval, stoppingToken);
                _bankAccountService.UpdateBalanceDaily();
            }
        }
    }
}
