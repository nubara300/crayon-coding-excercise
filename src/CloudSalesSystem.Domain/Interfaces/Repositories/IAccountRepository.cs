using CloudSalesSystem.Domain.Models.Accounts;

namespace CloudSalesSystem.Domain.Interfaces.Repositories;

public interface IAccountRepository : IBaseRepository<Account>
{
    Task<(List<Account> accounts, int total)> GetAccountsByCustomerId(Guid customerId, int page = 0, int pageSize = 10);
}