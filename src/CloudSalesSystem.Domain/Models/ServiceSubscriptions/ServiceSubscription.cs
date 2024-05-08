using CloudSalesSystem.Domain.Interfaces.Repositories;
using CloudSalesSystem.Domain.Models.Accounts;
using System.ComponentModel.DataAnnotations;
using License = CloudSalesSystem.Domain.Models.Licences.License;

namespace CloudSalesSystem.Domain.Models.ServiceSubscriptions;

public sealed class ServiceSubscription : BaseEntity<Guid>, IDomainEvents
{
    private ServiceSubscription(
    Guid id,
    Guid accountId,
    Guid subscriptionId,
    string softwareServiceName,
    DateTime validToDate,
    Guid transactionId,
    DateTime transactionTime)
    : base(id)
    {
        AccountId = accountId;
        SubscriptionId = subscriptionId;
        SoftwareServiceName = softwareServiceName;
        ValidToDate = validToDate;
        TransactionId = transactionId;
        TransactionTime = transactionTime;
    }

    public Guid SubscriptionId { get; private set; }
    [MaxLength(256)]
    public string SoftwareServiceName { get; private set; }
    [Range(0, 10000)]
    public int Quantity { get; private set; }
    public DateTime ValidToDate { get; private set; }
    public bool IsActive { get; private set; }
    public Account Account { get; private set; } = null!;
    public Guid AccountId { get; private set; }
    public Guid TransactionId { get; private set; }
    public DateTime TransactionTime { get; private set; }
    public ICollection<License> Licenses { get; } = [];

    public static ServiceSubscription Create(Guid accountId, Guid subscriptionId, string softwareServiceName, DateTime validToDate, Guid transactionId, DateTime transactionTime)
        => new(Guid.NewGuid(), accountId, subscriptionId, softwareServiceName, validToDate, transactionId, transactionTime);

    public void SetStateToInactive()
    {
        IsActive = false;
        //raise a domain event when subscirption state is changed to active
    }

    public void SetStateToActive()
    {
        IsActive = true;
        //raise a domain event when subscirption state is changed to active
    }

    public void AddLicenses(List<License> licenses)
    {
        foreach (var license in licenses)
        {
        }
    }

    public void AddLicense(License license)
    {
        _ = Licenses.Append(license);
        // raise domain event for each license assigned if needed
    }
}