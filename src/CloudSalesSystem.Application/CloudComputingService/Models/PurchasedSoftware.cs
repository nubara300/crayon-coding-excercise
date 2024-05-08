namespace CloudSalesSystem.Application.CloudComputingService.Models;

public record PurchasedSoftware(Guid SubscriptionId, string ServiceName, int Quantity, DateTime ValidToDate, Guid TransactionId, DateTime TransactionTime, decimal Price);
