using CloudSalesSystem.Domain;
using CloudSalesSystem.Domain.Interfaces.ServiceContext;
using Microsoft.AspNetCore.Http;

namespace CloudSalesSystem.Infrastructure.ServiceContexts
{
    public class ServiceContext(IHttpContextAccessor httpContextAccessor) : IServiceContext
    {

        public Guid GetCurrentUserId()
        {
            var userId = CLoudSalesConstants.CustomerId;
            return userId;
            // Example: Retrieving user id from claims
            // should be added after some sort of identity is added to the solution
            // var userIdClaim = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            // if (userIdClaim != null && Guid.TryParse(userIdClaim.Value, out Guid userId))
            // {
            //    return userId;
            // }

            // Handle case where user id is not found or invalid
            throw new InvalidOperationException("User id not found or invalid.");
        }
        public CustomerAccessType GetCurrentUserType()
        {
            // create a logic to determinate user origin, could also be read from claims
            return CustomerAccessType.System;
        }
        // Following methods are not implemented and are meant only for example purpose of this class
        public string GetApplicationVersion()
        {
            throw new NotImplementedException();
        }

        public string GetEnvironmentName()
        {
            throw new NotImplementedException();
        }

        public string GetRequestUrl()
        {
            throw new NotImplementedException();
        }

        public Guid GetUser()
        {
            throw new NotImplementedException();
        }

        public Guid GetUserInfo()
        {
            throw new NotImplementedException();
        }


    }
}
