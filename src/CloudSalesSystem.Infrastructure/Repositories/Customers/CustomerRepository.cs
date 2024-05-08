using CloudSalesSystem.Domain.Interfaces.Repositories;
using CloudSalesSystem.Domain.Models.Customers;

namespace CloudSalesSystem.Infrastructure.Repositories.Customers;

public class CustomerRepository(AppDbContext context) : BaseRepository<Customer>(context), ICustomerRepository
{
}