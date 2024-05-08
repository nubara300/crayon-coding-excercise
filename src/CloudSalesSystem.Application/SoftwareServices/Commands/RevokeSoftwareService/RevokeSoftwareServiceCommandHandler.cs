using MediatR;

namespace CloudSalesSystem.Application.SoftwareServices.Commands.RevokeSoftwareService
{
    internal sealed class RevokeLicenceQuantityCommandHandler : IRequestHandler<RevokeSoftwareLicenceCommand, RevokeSoftwareLicenceResponse>
    {
        public Task<RevokeSoftwareLicenceResponse> Handle(RevokeSoftwareLicenceCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
