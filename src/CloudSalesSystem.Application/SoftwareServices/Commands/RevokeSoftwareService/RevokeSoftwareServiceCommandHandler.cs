using CloudSalesSystem.Application.CloudComputingService;
using CloudSalesSystem.Domain.Interfaces.Repositories;
using MediatR;

namespace CloudSalesSystem.Application.SoftwareServices.Commands.RevokeSoftwareService
{
    internal sealed class RevokeLicenceQuantityCommandHandler : IRequestHandler<RevokeSoftwareLicenceCommand, RevokeSoftwareLicenceResponse>
    {
        private readonly ICloudComputingProviderService _cloudComputingService;
        private readonly IUnitOfWork _unitOfWork;

        public RevokeLicenceQuantityCommandHandler(ICloudComputingProviderService cloudComputingService, IUnitOfWork unitOfWork)
        {
            _cloudComputingService = cloudComputingService;
            _unitOfWork = unitOfWork;
        }

        public async Task<RevokeSoftwareLicenceResponse> Handle(RevokeSoftwareLicenceCommand request, CancellationToken cancellationToken)
        {
            return new RevokeSoftwareLicenceResponse(true, "Software service was revoked", request.SubscriptionId, request.SubscriptionId, DateTime.Now, Guid.NewGuid(), []);
        }
    }
}
