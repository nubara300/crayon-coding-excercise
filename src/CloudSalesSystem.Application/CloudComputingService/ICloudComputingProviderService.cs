using CloudSalesSystem.Application.CloudComputingService.Models;

namespace CloudSalesSystem.Application.CloudComputingService;

public interface ICloudComputingProviderService
{
    Task<SoftwareServiceResponse> GetSoftwareServices(int page = 0, int pageSize = 10, CancellationToken cancellationToken = default);
    Task<OrderServiceResponse> OrderSoftwareService(PursacheServiceRequest request, CancellationToken cancellationToken = default);
    Task<bool> ChangeSoftwareServiceQuantity(Guid subscriptionId, int newQuantity, CancellationToken cancellationToken = default);
    Task<bool> CancelSoftware(Guid subscriptionId, CancellationToken cancellationToken = default);
    Task<bool> ExtendSoftwareValidity(Guid subscriptionId, DateTime newValidityDate, CancellationToken cancellationToken = default);
}