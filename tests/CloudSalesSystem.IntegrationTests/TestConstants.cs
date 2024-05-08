using CloudSalesSystem.Application.CloudComputingService.Models;

namespace CloudSalesSystem.IntegrationTests;

internal class TestConstants
{
    public static OrderServiceResponse OrderResponse = new OrderServiceResponse(true, "Success", [], new PurchasedSoftware(Guid.NewGuid(), "test", 100, DateTime.Now.AddYears(1), Guid.NewGuid(), DateTime.Now, 100));
}
