
namespace CloudSalesSystem.Domain.Interfaces.ServiceContext
{
    public interface IServiceContext
    {
        public Guid GetCurrentUserId();
        public CustomerAccessType GetCurrentUserType();

        /// following methods are just examples of what could be added to service context beside user id
        public Guid GetUserInfo();
        public Guid GetUser();
        public string GetEnvironmentName();
        public string GetApplicationVersion();
        public string GetRequestUrl();
    }
}
