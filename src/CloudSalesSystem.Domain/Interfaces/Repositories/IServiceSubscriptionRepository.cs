
using CloudSalesSystem.Domain.Models.ServiceSubscriptions;

namespace CloudSalesSystem.Domain.Interfaces.Repositories;

public interface IServiceSubscriptionRepository : IBaseRepository<ServiceSubscription>
{
    Task<List<ServiceSubscription>> GetByCustomerId(Guid customerId);
}