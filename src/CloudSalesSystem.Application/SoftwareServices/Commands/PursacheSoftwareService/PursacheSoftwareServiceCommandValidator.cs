using CloudSalesSystem.Application.SoftwareServices.Commands.AssignSoftwareService;
using FluentValidation;

namespace CloudSalesSystem.Application.SoftwareServices.Commands.PursacheSoftwareService;

public class PursacheSoftwareServiceCommandValidator : AbstractValidator<PursacheSoftwareServiceCommand>
{
    public PursacheSoftwareServiceCommandValidator()
    {
        RuleFor(x => x.AccountId).NotNull();
        RuleFor(x => x.SubscriptionId).NotNull();
        RuleFor(x => x.Quantity).NotNull().GreaterThan(0);
        RuleFor(x => x.ValidToDate).NotNull().GreaterThan(DateTime.UtcNow);
    }
}
