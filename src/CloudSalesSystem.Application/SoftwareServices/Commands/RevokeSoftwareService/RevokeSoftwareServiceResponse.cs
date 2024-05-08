namespace CloudSalesSystem.Application.SoftwareServices.Commands.RevokeSoftwareService;

public sealed record RevokeSoftwareLicenceResponse(
    bool IsSuccess, string Message, Guid SubscriptionId, Guid ServiceId, DateTime TransactionDate, Guid TransactionId, IReadOnlyList<string> Errors);