namespace CloudSalesSystem.Domain.Interfaces.Repositories;
public interface IUnitOfWork
{
    IAccountRepository Accounts { get; }
    ICustomerRepository Customers { get; }
    ILicencesRepository Licences { get; }
    IServiceSubscriptionRepository ServiceSubscriptions { get; }

    /// <summary>
    /// Returns true save is a success;
    /// </summary>
    Task<bool> SaveChangesAsync();
}
