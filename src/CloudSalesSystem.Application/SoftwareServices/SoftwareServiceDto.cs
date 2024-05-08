namespace CloudSalesSystem.Application.SoftwareServices;

public sealed record SoftwareServiceDto(Guid Id, string SoftwareServiceName, string Description, int AvailableLicenses, DateTime ValidToDate, decimal Price);


public sealed record PurchasedServiceDto(Guid Id, Guid AccountId, string Name, string Description, int AvailableLicenses, DateTime ValidTo);