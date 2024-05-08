using MediatR;

namespace CloudSalesSystem.Application.Shared.Pagination;

public record PaginationRequest<TResponse> : IRequest<PaginationResponse<TResponse>>, IPaginationRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}