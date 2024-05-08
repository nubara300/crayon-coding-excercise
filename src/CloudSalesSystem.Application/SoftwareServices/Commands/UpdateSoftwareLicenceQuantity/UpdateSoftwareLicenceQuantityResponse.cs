namespace CloudSalesSystem.Application.SoftwareServices.Commands.UpdateSoftwareLicenceQuantity;

public sealed record UpdateSoftwareLicenceQuantityResponse(
    bool IsSuccess, string Message, Guid SubscriptionId, Guid ServiceId, DateTime TransactionDate, Guid TransactionId, IReadOnlyList<string> Errors);