using System;
using Microsoft.EntityFrameworkCore;

namespace EF_CORE_2_DbContext
{
	public class ExternalDbContext:DbContext
	{
        public DbSet<Wallet> Wallets { get; set; } = null!;

        public ExternalDbContext(DbContextOptions options)
            :base(options)
        {

        }
    }
}

