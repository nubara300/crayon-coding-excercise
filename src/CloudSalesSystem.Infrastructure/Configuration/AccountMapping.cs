using CloudSalesSystem.Domain.Models.Accounts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CloudSalesSystem.Domain;

namespace CloudSalesSystem.Infrastructure.Configuration;

public class AccountMapping : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(a => a.Name).HasMaxLength(256).IsRequired();
        builder.Property(a => a.Description).HasMaxLength(1000);
        builder.HasOne(a => a.Customer)
            .WithMany(c => c.Accounts)
            .HasForeignKey(a => a.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(a => a.ServiceSubscriptions)
            .WithOne(ss => ss.Account)
            .HasForeignKey(ss => ss.AccountId)
            .OnDelete(DeleteBehavior.Cascade);

        // Seed data on migration, we could also introduce DBInitialize,
        // where we would seed during runtime of the app
        builder.HasData(CLoudSalesConstants.Accounts);
    }
}
