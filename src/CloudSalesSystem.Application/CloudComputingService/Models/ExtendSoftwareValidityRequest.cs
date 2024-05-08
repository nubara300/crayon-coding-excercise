namespace CloudSalesSystem.Application.CloudComputingService.Models;

public record ExtendSoftwareValidityRequest(Guid SoftwareId, DateTime NewValidityDate);
public record ExtendSoftwareValidityResponse(bool IsSuccess, Guid SoftwareId, Guid TransactionId, DateTime TransactionTime);
