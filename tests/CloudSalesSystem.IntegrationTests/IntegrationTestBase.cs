using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CloudSalesSystem.Infrastructure;
using CloudSalesSystem.Application.CloudComputingService;
using Moq;
using CloudSalesSystem.Application.CloudComputingService.Models;

namespace CloudSalesSystem.IntegrationTests;

public class IntegrationTestBase : IClassFixture<WebApplicationFactory<Program>>
{
    protected WebApplicationFactory<Program> _factory = null!;
    protected readonly HttpClient _client;
    // Define mock implementation for ICloudComputingProviderService
    protected Mock<ICloudComputingProviderService> cloudComputingProviderServiceMock = new();

    public IntegrationTestBase(WebApplicationFactory<Program> factory)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
          .UseInMemoryDatabase(databaseName: "TestDatabase")
          .Options;

        _factory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped(_ => new AppDbContext(options));
                ConfigureMockedServices(services);
            });
        });
        _client = _factory.CreateClient();

        using (var dbContext = new AppDbContext(options))
        {
            dbContext.Customers.AddRange(CloudSalesSystem.Domain.CloudSalesConstants.Customer);
            dbContext.Accounts.AddRange(CloudSalesSystem.Domain.CloudSalesConstants.Accounts);
            // Add test data to the in-memory database if needed
            _ = dbContext.SaveChangesAsync().Result;
        }

        // Replace the real DbContext with the one using in-memory database
        // Mock repositories if needed
    }

    protected void ConfigureMockedServices(IServiceCollection services)
    {
        // arrange
        MockCloudComputingService();

        services.AddTransient<ICloudComputingProviderService>(_ => cloudComputingProviderServiceMock.Object);
        // Replace the real services with the mocked one
    }

    private void MockCloudComputingService()
    {
        cloudComputingProviderServiceMock.Setup(service => service.OrderSoftwareService(It.IsAny<PursacheServiceRequest>(), It.IsAny<CancellationToken>()))
          .ReturnsAsync(TestConstants.OrderResponse);
        // mock other responses as needed
        //cloudComputingProviderServiceMock.Setup(service => service.ChangeSoftwareServiceQuantity(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
        //.ReturnsAsync(/* Provide a mock response */);

        //cloudComputingProviderServiceMock.Setup(service => service.CancelSoftware(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
        //.ReturnsAsync(/* Provide a mock response */);

        //cloudComputingProviderServiceMock.Setup(service => service.ExtendSoftwareValidity(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<CancellationToken>()))
        //.ReturnsAsync(/* Provide a mock response */);
    }
}
