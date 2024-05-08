using CloudSalesSystem.Application.CloudComputingService;
using CloudSalesSystem.Application.Shared.Pagination;
using CloudSalesSystem.Domain.Interfaces.Cache;
using Mapster;
using MediatR;

namespace CloudSalesSystem.Application.SoftwareServices.Queries.ListSoftwareServices;

internal sealed class ListSoftwareServicesHandler : IRequestHandler<ListSoftwareServicesQuery, PaginationResponse<SoftwareServiceDto>>
{
    private readonly ICloudComputingProviderService _cloudComputingService;

    public ListSoftwareServicesHandler(ICloudComputingProviderService cloudComputingService, ICache cache)
    {
        _cloudComputingService = cloudComputingService;
    }

    public async Task<PaginationResponse<SoftwareServiceDto>> Handle(ListSoftwareServicesQuery request, CancellationToken cancellationToken)
    {
        var response = await _cloudComputingService.GetSoftwareServices(request.PageNumber, request.PageSize, cancellationToken);

        return new PaginationResponse<SoftwareServiceDto>
        {
            Items = response.Items.Adapt<List<SoftwareServiceDto>>(),
            Total = response.Total,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
        };
    }

}

