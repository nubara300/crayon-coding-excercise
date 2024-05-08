using CloudSalesSystem.Domain.Interfaces.Repositories;
using CloudSalesSystem.Domain.Models.Accounts;
using Microsoft.EntityFrameworkCore;

namespace CloudSalesSystem.Infrastructure.Repositories.Accounts
{
    public class AccountRepository(AppDbContext context) : BaseRepository<Account>(context), IAccountRepository
    {
        public async Task<(List<Account> accounts, int total)> GetAccountsByCustomerId(Guid customerId, int page = 0, int pageSize = 10)
        {
            var query = context.Accounts
                        .AsNoTracking()
                        .Where(x => x.IsDeleted == false);

            var total = await query.CountAsync();

            var accounts = await query
                .AsNoTracking()
                .Include(x => x.ServiceSubscriptions)
                .Where(x => x.CustomerId == customerId && x.IsDeleted == false)
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (accounts, total);
        }
    }
}