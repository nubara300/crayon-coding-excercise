using CloudSalesSystem.Domain.Interfaces.Repositories;
using CloudSalesSystem.Domain.Models.Licences;

namespace CloudSalesSystem.Infrastructure.Repositories.Licences;

public class LicensesRepository(AppDbContext context) : BaseRepository<License>(context), ILicencesRepository
{
}