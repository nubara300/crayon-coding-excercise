namespace CloudSalesSystem.Application.Accounts;

public sealed record SoftwareSubscriptionDto(Guid SubscriptionId, int Quantity, DateTime ValidToDate);