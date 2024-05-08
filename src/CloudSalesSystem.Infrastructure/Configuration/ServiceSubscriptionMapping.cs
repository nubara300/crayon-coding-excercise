using CloudSalesSystem.Domain.Models.ServiceSubscriptions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CloudSalesSystem.Infrastructure.Configuration;

public class ServiceSubscriptionMapping : IEntityTypeConfiguration<ServiceSubscription>
{
    public void Configure(EntityTypeBuilder<ServiceSubscription> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(ss => ss.SoftwareServiceName).HasMaxLength(256).IsRequired();
        builder.HasOne(ss => ss.Account)
            .WithMany(a => a.ServiceSubscriptions)
            .HasForeignKey(ss => ss.AccountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
