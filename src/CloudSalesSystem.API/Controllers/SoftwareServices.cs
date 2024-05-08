using CloudSalesSystem.Application.Shared.Pagination;
using CloudSalesSystem.Application.SoftwareServices;
using CloudSalesSystem.Application.SoftwareServices.Commands.AssignSoftwareService;
using CloudSalesSystem.Application.SoftwareServices.Commands.PursacheSoftwareService;
using CloudSalesSystem.Application.SoftwareServices.Commands.UpdateSoftwareLicenceQuantity;
using CloudSalesSystem.Application.SoftwareServices.Queries.ListSoftwareServices;
using CloudSalesSystem.Application.SoftwareServices.Queries.ListSoftwareServicesByAccount;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CloudSalesSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SoftwareServices(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// List available software services 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ListSoftwareServices(CancellationToken cancellationToken)
    {
        PaginationResponse<SoftwareServiceDto> response = await mediator.Send(new ListSoftwareServicesQuery(), cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// List purchased software services by account
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("list-pursached-software")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ListSoftwareServicesByAccountServices(CancellationToken cancellationToken)
    {
        PaginationResponse<SoftwareServiceDto> response = await mediator.Send(new ListAccountSubscriptionsQuery(), cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Pursache software licenses
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("pursache-software")]
    [ProducesResponseType(typeof(PursacheSoftwareServiceResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PursacheSoftware([FromBody] PursacheSoftwareServiceCommand command,
        CancellationToken cancellationToken)
    {
        PursacheSoftwareServiceResponse response = await mediator.Send(command, cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Change licence quantity for software
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("update-licence-quantity")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateLicencseQuantity([FromBody] UpdateSoftwareLicenceQuantityCommand command,
        CancellationToken cancellationToken)
    {
        UpdateSoftwareLicenceQuantityResponse result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Extends software license validity
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("extend-software-validity")]
    [ProducesResponseType(typeof(PursacheSoftwareServiceResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateSoftwareValidity([FromBody] UpdateSoftwareLicenceQuantityCommand command,
        CancellationToken cancellationToken)
    {
        UpdateSoftwareLicenceQuantityResponse response = await mediator.Send(command, cancellationToken);
        return Ok(response);
    }

}
