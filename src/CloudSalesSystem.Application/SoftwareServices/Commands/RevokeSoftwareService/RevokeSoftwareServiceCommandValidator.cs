using CloudSalesSystem.Application.SoftwareServices.Commands.RevokeSoftwareService;
using FluentValidation;

namespace CloudSalesSystem.Application.SoftwareServices.Commands.PursacheSoftwareService;

public class RevokeSoftwareLicenceValidator : AbstractValidator<RevokeSoftwareLicenceCommand>
{
    public RevokeSoftwareLicenceValidator()
    {
        RuleFor(x => x.ServiceId).NotNull();
        RuleFor(x => x.SubscriptionId).NotNull();
        //RuleFor(x => x.Quantity).NotNull().GreaterThan(0);
        //RuleFor(x => x.ValidToDate).NotNull().GreaterThan(DateOnly.FromDateTime(DateTime.UtcNow));
    }
}
