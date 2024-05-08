namespace CloudSalesSystem.Application.Accounts;

public sealed record AccountDto(Guid Id, string Name, string Description, IReadOnlyList<SoftwareSubscriptionDto> SoftwareSubscriptions);