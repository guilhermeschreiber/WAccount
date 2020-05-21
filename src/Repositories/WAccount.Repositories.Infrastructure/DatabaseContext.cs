using Microsoft.EntityFrameworkCore;
using WAccount.Domain.Models;

namespace WAccount.Repositories.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL("server=localhost;database=WA_DATABASE;user=guilherme;password=guilherme");
        }

        public DatabaseContext()
        {
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}
