using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CloudSalesSystem.Domain.Interfaces.Repositories;

namespace CloudSalesSystem.Infrastructure.Configuration;

public static class EntityMappingExtension
{
    public static void ConfigureBaseEntity<T>(this EntityTypeBuilder<T> builder) where T : BaseEntity<Guid>
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Version).IsRowVersion();
        builder.HasOne(b => b.CreatedBy)
            .WithMany()
            .HasForeignKey(b => b.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(b => b.ModifiedBy)
            .WithMany()
            .HasForeignKey(b => b.ModifiedById)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
