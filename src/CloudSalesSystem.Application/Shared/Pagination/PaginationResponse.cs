namespace CloudSalesSystem.Application.Shared.Pagination;

public class PaginationResponse<T>
{
    /// <summary>
    /// Paged items
    /// </summary>
    public List<T> Items { get; set; } = [];

    /// <summary>
    /// Total items count
    /// </summary>
    public long Total { get; set; } = 0;

    /// <summary>
    /// Current page
    /// </summary>
    public int PageNumber { get; set; } = 0;

    /// <summary>
    /// Page size
    /// </summary>
    public int PageSize { get; set; } = 0;
}