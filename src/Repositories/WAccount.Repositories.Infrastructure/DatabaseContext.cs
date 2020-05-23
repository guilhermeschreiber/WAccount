using Microsoft.EntityFrameworkCore;
using System.Data;
using WAccount.Domain.Models;

namespace WAccount.Repositories.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>().HasData(
                new UserAccount
                {
                    Id = 1,
                    Name = "Guilherme",
                    Email = "guiherme@schreiber.com",
                    Password = "123"
                }
                );
        }
    }
}
