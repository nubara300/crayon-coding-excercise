using CloudSalesSystem.Domain.Interfaces.Repositories;
using CloudSalesSystem.Domain.Models.Accounts;
using System.ComponentModel.DataAnnotations;

namespace CloudSalesSystem.Domain.Models.Customers;
public sealed class Customer : BaseEntity<Guid>
{
    private Customer(
        Guid id,
        string name,
        string description)
        : base(id)
    {
        Name = name;
        Description = description;
    }
    [MaxLength(256)]
    public string Name { get; private set; }
    [MaxLength(1000)]
    public string? Description { get; private set; }
    public ICollection<Account> Accounts { get; } = [];

    public static Customer Create(Guid id, string name, string description) => new(id, name, description);
    public void AddAccount(Account account)
    {
        this.Accounts.Add(account);
        // raise domain event
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException("Name cannot be empty");
        }
        Name = name;
    }

    public void SetDescritpion(string desc)
    {
        Description = desc;
    }

}
