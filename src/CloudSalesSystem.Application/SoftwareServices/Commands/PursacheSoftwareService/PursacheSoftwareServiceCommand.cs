using CloudSalesSystem.Application.SoftwareServices.Commands.PursacheSoftwareService;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CloudSalesSystem.Application.SoftwareServices.Commands.AssignSoftwareService;

public sealed record PursacheSoftwareServiceCommand(
  [Required] Guid AccountId,
  [Required] Guid SubscriptionId,
  [Required] int Quantity,
  [Required] DateTime ValidToDate) : IRequest<PursacheSoftwareServiceResponse>;
