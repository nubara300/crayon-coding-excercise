using CloudSalesSystem.Application.SoftwareServices.Commands.RevokeSoftwareService;
using FluentValidation;

namespace CloudSalesSystem.Application.SoftwareServices.Commands.PursacheSoftwareService;

public class RevokeSoftwareLicenceValidator : AbstractValidator<RevokeSoftwareLicenceCommand>
{
    public RevokeSoftwareLicenceValidator()
    {
        RuleFor(x => x.SubscriptionId).NotNull();
    }
}
