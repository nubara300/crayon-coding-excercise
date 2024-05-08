using CloudSalesSystem.Application.CloudComputingService;
using CloudSalesSystem.Application.CloudComputingService.Models;
using CloudSalesSystem.Application.SoftwareServices.Commands.AssignSoftwareService;
using CloudSalesSystem.Domain.Interfaces.Repositories;
using CloudSalesSystem.Domain.Interfaces.ServiceContext;
using CloudSalesSystem.Domain.Models.ServiceSubscriptions;
using Mapster;
using MediatR;

namespace CloudSalesSystem.Application.SoftwareServices.Commands.PursacheSoftwareService
{
    internal sealed class PursacheSoftwareServiceCommandHandler : IRequestHandler<PursacheSoftwareServiceCommand, PursacheSoftwareServiceResponse>
    {
        private readonly ICloudComputingProviderService _cloudComputingService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceContext _serviceContext;
        public PursacheSoftwareServiceCommandHandler(ICloudComputingProviderService cloudComputingService, IUnitOfWork unitOfWork, IServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
            _cloudComputingService = cloudComputingService;
            _unitOfWork = unitOfWork;
        }
        public async Task<PursacheSoftwareServiceResponse> Handle(PursacheSoftwareServiceCommand request, CancellationToken cancellationToken)
        {
            string accountError = await ValidateAccount(request.AccountId);
            string dateError = ValidateDate(request.ValidToDate);

            if (!string.IsNullOrWhiteSpace(accountError) || !string.IsNullOrWhiteSpace(dateError))
            {
                var errors = new List<string> { accountError, dateError };
                return new PursacheSoftwareServiceResponse(true, "Order failed!", null, errors.Where(x => !string.IsNullOrWhiteSpace(x)).ToList());
            }

            var pursacheServiceRequest = request.Adapt<PursacheServiceRequest>();
            var response = await _cloudComputingService.OrderSoftwareService(pursacheServiceRequest);

            if (response.Success)
            {
                var serviceSubscription = MapResponseToServiceSubscription(request.AccountId, response.PurchasedSoftware);

                _unitOfWork.ServiceSubscriptions.Add(serviceSubscription);
                await _unitOfWork.SaveChangesAsync();
                // raise domain event subscription created
                return new PursacheSoftwareServiceResponse(true, response.Message, response.PurchasedSoftware, []);
            }

            return new PursacheSoftwareServiceResponse(true, "Order failed!", null, response.Errors);
        }

        private string ValidateDate(DateTime validToDate)
        {
            if (validToDate < DateTime.Now)
            {
                return "Date of license expiration must be in future";
            }
            return string.Empty;
        }

        private async Task<string> ValidateAccount(Guid accountId)
        {

            var accountExists = await _unitOfWork.Accounts.AnyAsync(x => x.Id == accountId);
            if (!accountExists)
            {
                return $"User with id={accountId} not found";
            }
            return string.Empty;
        }

        private ServiceSubscription MapResponseToServiceSubscription(Guid accountId, PurchasedSoftware purchasedSoftware)
        {
            return ServiceSubscription.Create(accountId,
                    purchasedSoftware.SubscriptionId, purchasedSoftware.ServiceName,
                    purchasedSoftware.ValidToDate, purchasedSoftware.TransactionId,
                    purchasedSoftware.TransactionTime,
                    purchasedSoftware.Price);
        }
    }
}
