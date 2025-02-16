using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_CORE_2_DbContext.Data
{
    public class WalletConfigration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.ToTable("Wallets");

            builder.Property(w => w.Id)
                   .HasColumnName("Id");
            builder.HasKey(w => w.Id);
            

            builder.Property(w => w.Holder)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(w => w.Balance)
                .HasColumnType("decimal(18,2)");
        }


    }
}

