using System;
using EF_CORE_2_DbContext.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF_CORE_2_DbContext
{
	public class InternalDbContext:DbContext
	{
        public DbSet<Wallet> Wallets { get; set; }=null!; 


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var constr = config.GetSection("constr").Value;
            optionsBuilder.UseSqlServer(constr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new WalletConfigration().Configure(modelBuilder.Entity<Wallet>());
        }


    }
}

