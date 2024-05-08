using CloudSalesSystem.Domain.Interfaces.Repositories;
using CloudSalesSystem.Domain.Models.ServiceSubscriptions;

namespace CloudSalesSystem.Infrastructure.Repositories.ServiceSubscriptionsRepository;

public class ServiceSubscriptionRepository(AppDbContext context) : BaseRepository<ServiceSubscription>(context), IServiceSubscriptionRepository
{
    public async Task<List<ServiceSubscription>> GetByCustomerId(Guid customerId)
    {
        return await GetListAsync(x => x.CreatedById == customerId);
    }
}
