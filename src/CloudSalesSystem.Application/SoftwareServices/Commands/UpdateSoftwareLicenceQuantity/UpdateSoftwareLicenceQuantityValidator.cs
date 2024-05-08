using CloudSalesSystem.Application.SoftwareServices.Commands.AssignSoftwareService;
using FluentValidation;

namespace CloudSalesSystem.Application.SoftwareServices.Commands.UpdateSoftwareLicenceQuantity;

public class PursacheSoftwareServiceValidator : AbstractValidator<PursacheSoftwareServiceCommand>
{
    public PursacheSoftwareServiceValidator()
    {
        RuleFor(x => x.AccountId).NotNull();
        RuleFor(x => x.SubscriptionId).NotNull();
        RuleFor(x => x.Quantity).NotNull().GreaterThan(0);
        RuleFor(x => x.ValidToDate).NotNull().GreaterThan(DateTime.UtcNow);
    }
}
