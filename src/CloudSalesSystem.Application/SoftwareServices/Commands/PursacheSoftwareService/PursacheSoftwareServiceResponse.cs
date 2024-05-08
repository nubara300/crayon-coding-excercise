using CloudSalesSystem.Application.CloudComputingService.Models;

namespace CloudSalesSystem.Application.SoftwareServices.Commands.PursacheSoftwareService;

public sealed record PursacheSoftwareServiceResponse(
    bool IsSuccess, string Message, PurchasedSoftware PurchasedSoftware, IReadOnlyList<string> Errors);