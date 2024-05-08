namespace CloudSalesSystem.Application.SoftwareServices;

public sealed record SoftwareServiceDto(Guid Id, string Name, string Description, int AvailableLicenses, DateTime ValidTo, decimal Price);


public sealed record PurchasedServiceDto(Guid Id, Guid AccountId, string Name, string Description, int AvailableLicenses, DateTime ValidTo);