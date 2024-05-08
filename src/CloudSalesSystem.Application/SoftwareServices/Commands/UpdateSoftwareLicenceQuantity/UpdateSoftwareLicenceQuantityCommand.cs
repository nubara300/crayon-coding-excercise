using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CloudSalesSystem.Application.SoftwareServices.Commands.UpdateSoftwareLicenceQuantity;

public sealed record UpdateSoftwareLicenceQuantityCommand(
[Required] Guid SubscriptionId, int NewQuantity) : IRequest<UpdateSoftwareLicenceQuantityResponse>;
