using CloudSalesSystem.Application.Shared.Pagination;
using MediatR;

namespace CloudSalesSystem.Application.SoftwareServices.Queries.ListSoftwareServices;
public sealed record ListSoftwareServicesQuery() : PaginationRequest<SoftwareServiceDto>, IRequest<PaginationResponse<SoftwareServiceDto>>;
