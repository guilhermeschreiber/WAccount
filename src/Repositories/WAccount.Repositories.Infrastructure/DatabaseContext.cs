using Microsoft.EntityFrameworkCore;
using System;
using WAccount.Domain.Models;
using WAccount.Shared;

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
                    Name = "Guilherme Schreiber",
                    Email = "admin@admin.com",
                    Password = MD5Hash.GetHash("123"),
                    UpdatedAt = DateTime.Now.AddDays(-30),
                    Balance = 7200
                }
                );
        }
    }
}
