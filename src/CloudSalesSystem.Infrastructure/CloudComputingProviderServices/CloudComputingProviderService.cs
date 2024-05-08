using CloudSalesSystem.Application.CloudComputingService;
using CloudSalesSystem.Application.CloudComputingService.Models;
using Newtonsoft.Json;

namespace CloudSalesSystem.Infrastructure.CloudComputingProviderServices;

public class CloudComputingProviderService : ICloudComputingProviderService
{
    private readonly HttpClient _httpClient;

    public CloudComputingProviderService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient(nameof(CloudComputingProviderService));
    }

    public async Task<SoftwareServiceResponse> GetSoftwareServices(int page = 0, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync($"/CloudComputing/software-services?page={page}&pageSize={pageSize}", cancellationToken);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonConvert.DeserializeObject<SoftwareServiceResponse>(content);
    }

    public async Task<OrderServiceResponse> OrderSoftwareService(PursacheServiceRequest request, CancellationToken cancellationToken = default)
    {
        var jsonContent = JsonConvert.SerializeObject(request);
        var httpContent = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("/CloudComputing/order-service", httpContent, cancellationToken);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<OrderServiceResponse>(responseContent);// JsonSerializer.Deserialize<OrderServiceResponse>(responseContent);
    }

    public async Task<bool> ChangeSoftwareServiceQuantity(Guid subscriptionId,  int newQuantity, CancellationToken cancellationToken = default)
    {
        var request = new ChangeServiceQuantityRequest(subscriptionId, newQuantity);
        var jsonContent = JsonConvert.SerializeObject(request);
        var httpContent = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync("/api/change-service-quantity", httpContent, cancellationToken);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> CancelSoftware(Guid subscriptionId, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.DeleteAsync($"/api/cancel-service/{subscriptionId}", cancellationToken);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> ExtendSoftwareValidity(Guid softwareId, DateTime newValidityDate, CancellationToken cancellationToken = default)
    {
        var request = new ExtendSoftwareValidityRequest(softwareId, newValidityDate);
        var jsonContent = JsonConvert.SerializeObject(request);
        var httpContent = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync("/api/extend-service-validity", httpContent, cancellationToken);
        return response.IsSuccessStatusCode;
    }

}