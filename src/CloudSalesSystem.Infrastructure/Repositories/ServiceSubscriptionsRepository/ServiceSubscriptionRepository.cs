using CloudSalesSystem.Domain.Interfaces.Repositories;
using CloudSalesSystem.Domain.Models.ServiceSubscriptions;
using Microsoft.EntityFrameworkCore;

namespace CloudSalesSystem.Infrastructure.Repositories.ServiceSubscriptionsRepository;

public class ServiceSubscriptionRepository(AppDbContext context) : BaseRepository<ServiceSubscription>(context), IServiceSubscriptionRepository
{
    public async Task<List<ServiceSubscription>> GetByCustomerId(Guid customerId)
    {
        return await context.ServiceSubscriptions
            .AsNoTracking()
            .Include(x => x.Licenses)
            .Where(x => x.CreatedById == customerId)
            .ToListAsync();
    }
}
