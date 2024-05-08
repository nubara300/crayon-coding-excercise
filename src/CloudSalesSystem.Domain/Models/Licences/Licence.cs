using CloudSalesSystem.Domain.Interfaces.Repositories;
using CloudSalesSystem.Domain.Models.Accounts;
using CloudSalesSystem.Domain.Models.ServiceSubscriptions;
using System.ComponentModel.DataAnnotations;

namespace CloudSalesSystem.Domain.Models.Licences;

public class License : BaseEntity<Guid>
{
    private License(
       Guid id,
       Guid serviceSubscriptionId,
       string licenseKey)
       : base(id)
    {
        ServiceSubscriptionId = serviceSubscriptionId;
        LicenseKey = licenseKey;
    }

    [MaxLength(256)]
    public string LicenseKey { get; private set; } = string.Empty;
    public Guid ServiceSubscriptionId { get; private set; }
    public ServiceSubscription ServiceSubscription { get; private set; } = null!;

    public static License Create(Guid serviceSubscriptionId, string licenseKey) => new(Guid.NewGuid(), serviceSubscriptionId, licenseKey);

    public void SetLicenseKey(string key)
    {
        LicenseKey = key;
        // raise domain event for license changed/added
    }

}
