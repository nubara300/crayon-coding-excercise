using CloudSalesSystem.Application.Shared.Pagination;
using CloudSalesSystem.Domain.Interfaces.Repositories;
using CloudSalesSystem.Domain.Interfaces.ServiceContext;
using Mapster;
using MediatR;

namespace CloudSalesSystem.Application.Accounts.Queries.ListAccounts;

public sealed class ListAccountsQueryHandler : IRequestHandler<ListAccountsQuery, PaginationResponse<AccountDto>>
{
    private readonly IServiceContext _serviceContext;
    private readonly IUnitOfWork _unitOfWork;

    public ListAccountsQueryHandler(
        IServiceContext serviceContext,
        IUnitOfWork unitOfWork)
    {
        _serviceContext = serviceContext;
        _unitOfWork = unitOfWork;
    }

    public async Task<PaginationResponse<AccountDto>> Handle(ListAccountsQuery request, CancellationToken cancellationToken)
    {
        var currentUserId = _serviceContext.GetCurrentUserId();

        var (accounts, total) = await _unitOfWork.Accounts.GetAccountsByCustomerId(currentUserId, request.PageNumber, request.PageSize);

        return new PaginationResponse<AccountDto>
        {
            Items = accounts.Adapt<List<AccountDto>>(),
            Total = total,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
        };
    }

}

