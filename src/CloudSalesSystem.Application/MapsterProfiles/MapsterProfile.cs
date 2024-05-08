using CloudSalesSystem.Application.SoftwareServices;
using CloudSalesSystem.Domain.Models.ServiceSubscriptions;
using Mapster;

namespace CloudSalesSystem.Application.MapsterProfiles;
public class MapsterProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Define your mappings here
        config.NewConfig<ServiceSubscription, SoftwareServiceDto>()
            .Map(dest => dest.AvailableLicenses, opt => opt.Licenses.Count);
    }
}
