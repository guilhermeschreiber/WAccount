using Microsoft.EntityFrameworkCore;
using WAccount.Domain.Models;

namespace WAccount.Repositories.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
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
