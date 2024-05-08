using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CloudSalesSystem.Application.SoftwareServices.Commands.RevokeSoftwareService;

public sealed record RevokeSoftwareLicenceCommand(
[Required] Guid SubscriptionId) : IRequest<RevokeSoftwareLicenceResponse>;
