using CloudSalesSystem.Application.CloudComputingService;
using CloudSalesSystem.Application.Shared.Pagination;
using CloudSalesSystem.Domain.Interfaces.Repositories;
using CloudSalesSystem.Domain.Interfaces.ServiceContext;
using Mapster;
using MediatR;

namespace CloudSalesSystem.Application.SoftwareServices.Queries.ListSoftwareServicesByAccount;

internal sealed class ListAccountSubscriptionsHandler : IRequestHandler<ListAccountSubscriptionsQuery, PaginationResponse<SoftwareServiceDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceContext _serviceContext;

    public ListAccountSubscriptionsHandler(IUnitOfWork unitOfWork, IServiceContext serviceContext)
    {
        _unitOfWork = unitOfWork;
        _serviceContext = serviceContext;
    }

    public async Task<PaginationResponse<SoftwareServiceDto>> Handle(ListAccountSubscriptionsQuery request, CancellationToken cancellationToken)
    {
        var customerId = _serviceContext.GetCurrentUserId();
        var response = await _unitOfWork.ServiceSubscriptions.GetByCustomerId(customerId);

        // ToDo missing mappings configuration to add license count to the response
        return new PaginationResponse<SoftwareServiceDto>
        {
            Items = response.Adapt<List<SoftwareServiceDto>>(),
            Total = response.Count,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
        };
    }

}