using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CloudSalesSystem.Domain.Models.Licences;

namespace CloudSalesSystem.Infrastructure.Configuration;

public class LicenseMapping : IEntityTypeConfiguration<License>
{
    public void Configure(EntityTypeBuilder<License> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(l => l.LicenseKey).HasMaxLength(256).IsRequired();
        builder.HasOne(l => l.ServiceSubscription)
            .WithMany(ss => ss.Licenses)
            .HasForeignKey(l => l.ServiceSubscriptionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
