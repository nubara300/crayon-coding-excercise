using CloudSalesSystem.Domain.Interfaces.Repositories;
using CloudSalesSystem.Domain.Models.Customers;
using CloudSalesSystem.Domain.Models.ServiceSubscriptions;
using System.ComponentModel.DataAnnotations;

namespace CloudSalesSystem.Domain.Models.Accounts;
public sealed class Account : BaseEntity<Guid>
{
    private Account(
        Guid id,
        Guid customerId,
        string name,
        string? description)
        : base(id)
    {
        Name = name;
        Description = description;
        CustomerId = customerId;
    }
    [MaxLength(256)]
    public string Name { get; private set; }
    [MaxLength(1000)]
    public string? Description { get; private set; }
    public Guid CustomerId { get; private set; }
    public Customer Customer { get; private set; } = null!;
    public ICollection<ServiceSubscription> ServiceSubscriptions { get; } = [];

    public static Account Create(Guid accountId, Guid customerId, string name, string description) => new(accountId, customerId, name, description);

    public void SetCustomerId(Guid customerId) => CustomerId = customerId;

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException($"{nameof(name)} cannot be empty");
        }
        Name = name;
    }

    public void SetDescritpion(string desc) => Description = desc;

}
