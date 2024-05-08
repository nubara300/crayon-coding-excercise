using CloudSalesSystem.Application.Accounts;
using CloudSalesSystem.Application.Accounts.Queries.ListAccounts;
using CloudSalesSystem.Application.Shared.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CloudSalesSystem.API.Controllers;

[ApiController]
//[Authorize]
[Route("api/[controller]")]
public class AccountsController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// List customer accounts
    /// </summary>
    /// <param name="listAccountsQuery"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>List of account Response Model</returns>
    [HttpGet]
    [ProducesResponseType(typeof(PaginationResponse<AccountDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ListAccounts([FromQuery] ListAccountsQuery listAccountsQuery, CancellationToken cancellationToken)
    {
        PaginationResponse<AccountDto> response = await mediator.Send(listAccountsQuery, cancellationToken);
        return Ok(response);
    }
}
