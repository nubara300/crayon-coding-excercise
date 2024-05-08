using CloudSalesSystem.Domain.Models.Customers;
using System.ComponentModel.DataAnnotations;

namespace CloudSalesSystem.Domain.Interfaces.Repositories;

public interface IBaseAuditableEntity
{
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset? DateModified { get; set; }
    public Guid? CreatedById { get; set; }
    public Customer CreatedBy { get; set; }
    public Guid? ModifiedById { get; set; }
    public Customer? ModifiedBy { get; set; }
}