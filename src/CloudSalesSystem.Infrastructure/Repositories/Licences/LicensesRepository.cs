using CloudSalesSystem.Domain.Interfaces.Repositories;
using CloudSalesSystem.Domain.Models.Licences;
using Microsoft.EntityFrameworkCore;

namespace CloudSalesSystem.Infrastructure.Repositories.Licences;

public class LicensesRepository(AppDbContext context) : BaseRepository<License>(context), ILicencesRepository
{
    public async Task<int> GetTotalLicencesNumberBySubscriptionId(Guid subscriptionId)
    {
        return await context.Licences.CountAsync(x=>x.ServiceSubscriptionId == subscriptionId);
    }
}