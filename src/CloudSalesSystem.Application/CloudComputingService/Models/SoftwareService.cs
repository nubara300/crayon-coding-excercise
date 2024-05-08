namespace CloudSalesSystem.Application.CloudComputingService.Models;

public record SoftwareServiceResponse(IReadOnlyList<SoftwareService> Items, int Page, int PageSize, int Total);
public record SoftwareService(Guid Id, string Name, string Description, int AvailableLicenses, decimal Price, DateTime ValidToDate);
