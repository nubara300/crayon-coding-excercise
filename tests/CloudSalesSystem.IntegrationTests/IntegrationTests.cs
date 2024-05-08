using CloudSalesSystem.Application.Accounts;
using CloudSalesSystem.Application.Shared.Pagination;
using CloudSalesSystem.Application.SoftwareServices.Commands.AssignSoftwareService;
using CloudSalesSystem.Application.SoftwareServices.Commands.PursacheSoftwareService;
using CloudSalesSystem.Domain;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;

namespace CloudSalesSystem.IntegrationTests;
public class IntegrationTests : IntegrationTestBase
{
    public IntegrationTests(WebApplicationFactory<Program> factory) : base(factory) { }

    [Fact]
    public async Task GetAccounts_ReturnsListOfAccountsForCustomer()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/api/Accounts");
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<PaginationResponse<AccountDto>>(content);

        // Assert
        Assert.True(response.IsSuccessStatusCode);
        Assert.NotNull(result);
        Assert.True(result.Items.Any());
    }

    [Fact]
    public async Task PostPursacheSoftware_ReturnsOrderResponse()
    {
        // Arrange
        var client = _factory.CreateClient();
        var request = new PursacheSoftwareServiceCommand(CloudSalesConstants.AccountId1, Guid.NewGuid(), 100, DateTime.Now.AddDays(10));
        var jsonContent = JsonConvert.SerializeObject(request);
        var httpContent = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        // Act
        var response = await client.PostAsync("/api/SoftwareServices/pursache-software", httpContent);

        // Assert
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<PursacheSoftwareServiceResponse>(content);
        Assert.True(response.IsSuccessStatusCode);
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.PurchasedSoftware);
    }

    // Add more tests for other endpoints as needed
}
