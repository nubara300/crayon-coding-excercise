using CloudSalesSystem.Domain;
using Microsoft.AspNetCore.Http;

namespace CloudSalesSystem.Infrastructure.Repositories;

public class HttpUnitOfWork : UnitOfWork
{
    public HttpUnitOfWork(AppDbContext context, IHttpContextAccessor httpAccessor) : base(context)
    {
        // example of retrieveng the user id from context and claims
        // var id = httpAccessor.HttpContext?.User.FindFirst("jti")?.Value?.Trim();
        var id = CLoudSalesConstants.CustomerId.ToString();
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new UnauthorizedAccessException("User id is missing from the context!");
        }

        context.CurrentUserId = id == null ? Guid.Empty : Guid.Parse(id);
    }
}
