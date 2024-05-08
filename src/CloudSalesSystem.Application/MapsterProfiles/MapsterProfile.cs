using CloudSalesSystem.Application.CloudComputingService.Models;
using CloudSalesSystem.Domain.Models.ServiceSubscriptions;
using Mapster;

namespace CloudSalesSystem.Application.MapsterProfiles
{
    public class MapsterProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Define your mappings here
            config.NewConfig<OrderServiceResponse, ServiceSubscription>()
                .Map(dest => dest.Quantity, opt => opt.PurchasedSoftware.Quantity)
                .Map(dest => dest.TransactionId, opt => opt.PurchasedSoftware.TransactionId)
                .Map(dest => dest.TransactionTime, opt => opt.PurchasedSoftware.TransactionTime);
        }
    }
}
