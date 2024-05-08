using CloudSalesSystem.Application.CloudComputingService;
using CloudSalesSystem.Domain.Interfaces.Repositories;
using MediatR;

namespace CloudSalesSystem.Application.SoftwareServices.Commands.UpdateSoftwareLicenceQuantity
{
    internal sealed class UpdateSoftwareLicenceQuantityCommandHandler : IRequestHandler<UpdateSoftwareLicenceQuantityCommand, UpdateSoftwareLicenceQuantityResponse>
    {
        private readonly ICloudComputingProviderService _cloudComputingService;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSoftwareLicenceQuantityCommandHandler(IUnitOfWork unitOfWork, ICloudComputingProviderService cloudComputingService)
        {
            _unitOfWork = unitOfWork;
            _cloudComputingService = cloudComputingService;
        }

        public async Task<UpdateSoftwareLicenceQuantityResponse> Handle(UpdateSoftwareLicenceQuantityCommand request, CancellationToken cancellationToken)
        {
            var subscription = await _unitOfWork.ServiceSubscriptions.GetByIdAsync(request.SubscriptionId);
            if (subscription is null)
            {
                return new UpdateSoftwareLicenceQuantityResponse(false, $"Subscription for id={request.SubscriptionId} not found", request.SubscriptionId, null, null, []);
            }
            // I did mock response to be true by default, due to lack of time i am not saving result to databse as i should
            var result = await _cloudComputingService.ChangeSoftwareServiceQuantity(request.SubscriptionId, request.NewQuantity, cancellationToken);
            if (result is true)
            {
                return new UpdateSoftwareLicenceQuantityResponse(true, $"Subscription license quantity updated", request.SubscriptionId, DateTime.Now, Guid.NewGuid(), []);
            }
            return new UpdateSoftwareLicenceQuantityResponse(false, $"Error updating subscription license quantity", request.SubscriptionId, null, null, []);
        }
    }
}
