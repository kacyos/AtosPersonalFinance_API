using AtosPersonalFinance_API.Data.Mapping;
using AtosPersonalFinance_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AtosPersonalFinance_API.Data
{
    public class Context : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build()
                .GetConnectionString("DEV");

            // optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new TransactionMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
