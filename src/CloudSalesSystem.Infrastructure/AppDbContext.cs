using CloudSalesSystem.Domain.Interfaces.Repositories;
using CloudSalesSystem.Domain.Models.Accounts;
using CloudSalesSystem.Domain.Models.Customers;
using CloudSalesSystem.Domain.Models.Licences;
using CloudSalesSystem.Domain.Models.ServiceSubscriptions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CloudSalesSystem.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public Guid CurrentUserId { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ServiceSubscription> ServiceSubscriptions { get; set; }
        public DbSet<License> Licences { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=CinApp;Integrated Security=True;MultipleActiveResultSets=true;Trusted_Connection=True;TrustServerCertificate=true;Encrypt=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditEntities();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateAuditEntities()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IBaseAuditableEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                var entity = (IBaseAuditableEntity)entry.Entity;
                var now = DateTimeOffset.Now;

                if (entry.State == EntityState.Added)
                {
                    entity.DateCreated = now;
                    entity.CreatedById = CurrentUserId;
                }
                else
                {
                    base.Entry(entity).Property(x => x.CreatedById).IsModified = false;
                    base.Entry(entity).Property(x => x.DateCreated).IsModified = false;
                    entity.DateModified = now;
                    entity.ModifiedById = CurrentUserId;
                }
            }
        }
    }
}
