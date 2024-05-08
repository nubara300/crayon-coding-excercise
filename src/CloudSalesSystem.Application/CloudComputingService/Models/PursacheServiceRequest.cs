namespace CloudSalesSystem.Application.CloudComputingService.Models;

public record PursacheServiceRequest(Guid SubscriptionId, int Quantity, DateTime ValidToDate);
