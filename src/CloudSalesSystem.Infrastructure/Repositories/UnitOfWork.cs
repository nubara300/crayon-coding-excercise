using CloudSalesSystem.Domain.Interfaces.Repositories;
using CloudSalesSystem.Infrastructure.Repositories.Accounts;
using CloudSalesSystem.Infrastructure.Repositories.Customers;
using CloudSalesSystem.Infrastructure.Repositories.Licences;
using CloudSalesSystem.Infrastructure.Repositories.ServiceSubscriptionsRepository;

namespace CloudSalesSystem.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IAccountRepository _accountsRepository;

        private ICustomerRepository _customerRepository;
        private ILicencesRepository _licencesRepository;
        private IServiceSubscriptionRepository _serviceSubscriptions;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IAccountRepository Accounts
        {
            get
            {
                _accountsRepository ??= new AccountRepository(_context);

                return _accountsRepository;
            }
        }

        public ICustomerRepository Customers
        {
            get
            {
                _customerRepository ??= new CustomerRepository(_context);

                return _customerRepository;
            }
        }

        public ILicencesRepository Licences
        {
            get
            {
                _licencesRepository ??= new LicensesRepository(_context);

                return _licencesRepository;
            }
        }

        public IServiceSubscriptionRepository ServiceSubscriptions
        {
            get
            {
                _serviceSubscriptions ??= new ServiceSubscriptionRepository(_context);

                return _serviceSubscriptions;
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            var saveResult = await _context.SaveChangesAsync();
            return saveResult > 0;
        }
    }
}
