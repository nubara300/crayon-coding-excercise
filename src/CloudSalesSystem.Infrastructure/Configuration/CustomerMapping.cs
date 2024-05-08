using CloudSalesSystem.Domain.Models.Customers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CloudSalesSystem.Domain;

namespace CloudSalesSystem.Infrastructure.Configuration;

public class CustomerMapping : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(c => c.Name).HasMaxLength(256).IsRequired();
        builder.Property(c => c.Description).HasMaxLength(1000);

        // Seed data on migration, we could also introduce DBInitialize,
        // where we would seed during runtime of the app
        builder.HasData(CloudSalesConstants.Customer);
    }
}
