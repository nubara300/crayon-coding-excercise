namespace CloudSalesSystem.Application.CloudComputingService.Models;

public record OrderServiceResponse(bool Success, string Message, IReadOnlyList<string> Errors, PurchasedSoftware PurchasedSoftware);
