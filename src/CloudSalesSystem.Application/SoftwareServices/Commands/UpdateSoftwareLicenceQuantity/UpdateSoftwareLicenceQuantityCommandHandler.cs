using MediatR;

namespace CloudSalesSystem.Application.SoftwareServices.Commands.UpdateSoftwareLicenceQuantity
{
    internal sealed class UpdateSoftwareLicenceQuantityCommandHandler : IRequestHandler<UpdateSoftwareLicenceQuantityCommand, UpdateSoftwareLicenceQuantityResponse>
    {
        public Task<UpdateSoftwareLicenceQuantityResponse> Handle(UpdateSoftwareLicenceQuantityCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
