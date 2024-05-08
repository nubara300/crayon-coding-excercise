using CloudSalesSystem.Domain.Models.Licences;

namespace CloudSalesSystem.Domain.Interfaces.Repositories;

public interface ILicencesRepository : IBaseRepository<License>
{
    Task<int> GetTotalLicencesNumberBySubscriptionId(Guid subscriptionId);
}