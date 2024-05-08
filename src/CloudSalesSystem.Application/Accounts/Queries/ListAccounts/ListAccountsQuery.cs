using CloudSalesSystem.Application.Shared.Pagination;
using MediatR;

namespace CloudSalesSystem.Application.Accounts.Queries.ListAccounts;
public sealed record ListAccountsQuery() : PaginationRequest<AccountDto>, IRequest<PaginationResponse<AccountDto>>;

