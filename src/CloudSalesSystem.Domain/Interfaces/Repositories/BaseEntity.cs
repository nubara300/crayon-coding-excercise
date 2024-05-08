using CloudSalesSystem.Domain.Models.Customers;
using System.ComponentModel.DataAnnotations;

namespace CloudSalesSystem.Domain.Interfaces.Repositories;

public class BaseEntity<TId> : IBaseAuditableEntity
{
    protected BaseEntity(TId id)
    {
        Id = id;
    }

    public TId Id { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset? DateModified { get; set; }
    public bool IsDeleted { get; set; } = false;
    public Guid? CreatedById { get; set; }
    public Customer CreatedBy { get; set; }
    public Guid? ModifiedById { get; set; }
    public Customer? ModifiedBy { get; set; }
    [Timestamp]
    public byte[] Version { get; set; }
}
