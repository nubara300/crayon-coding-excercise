namespace CloudSalesSystem.Application.Shared.Pagination;

public interface IPaginationRequest
{
    int PageNumber { get; set; }
    int PageSize { get; set; }
}