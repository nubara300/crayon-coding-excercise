namespace CloudSalesSystem.Application.CloudComputingService.Models;

public record ChangeServiceQuantityRequest(Guid SubscriptionId, int NewQuantity);