using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using WAccount.BackgroundServices.MainService;
using WAccount.Domain.Services;
using WAccount.Domain.Services.Interfaces;
using WAccount.Repositories.Infrastructure;
using WAccount.Repositories.Infrastructure.Interfaces;

namespace WAccount.API.MainAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            services.AddSingleton<IBankAccountService, BankAccountService>();
            services.AddSingleton<IPendingTransactionsService, PendingTransactionsService>();
            services.AddSingleton<IUserLoginService, UserLoginService>();

            services.AddHostedService<CurrentAccountBackgroundService>();
            services.AddHostedService<TransactionResolverBackgroundService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            CreateDatabase(services.GetRequiredService<DatabaseContext>());
        }

        private void CreateDatabase (DatabaseContext context)
        {
            try
            {
                context.Database?.Migrate();
            }
            catch
            {
                Console.WriteLine("########################## Database connection error.\n\n" +
                    "Please, verify your string connection or your MySQL service\n\n" +
                    "##########################");
            }
        }
    }
}
