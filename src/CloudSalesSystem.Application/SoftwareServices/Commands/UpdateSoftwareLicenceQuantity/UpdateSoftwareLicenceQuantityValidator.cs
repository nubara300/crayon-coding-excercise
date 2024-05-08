using FluentValidation;

namespace CloudSalesSystem.Application.SoftwareServices.Commands.UpdateSoftwareLicenceQuantity;

public class PursacheSoftwareServiceValidator : AbstractValidator<UpdateSoftwareLicenceQuantityCommand>
{
    public PursacheSoftwareServiceValidator()
    {
        RuleFor(x => x.SubscriptionId).NotNull();
    }
}
