using CloudSalesSystem.Application.Shared.Pagination;
using MediatR;


namespace CloudSalesSystem.Application.SoftwareServices.Queries.ListSoftwareServicesByAccount;
public sealed record ListAccountSubscriptionsQuery() : PaginationRequest<SoftwareServiceDto>, IRequest<PaginationResponse<SoftwareServiceDto>>;