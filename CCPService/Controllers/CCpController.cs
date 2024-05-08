using CloudSalesSystem.Application.CloudComputingService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CCPService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CloudComputingController : ControllerBase
    {
        private readonly ILogger<CloudComputingController> _logger;

        public CloudComputingController(ILogger<CloudComputingController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return Ok("OK");
        }

        [HttpGet("software-services")]
        public async Task<IActionResult> GetSoftwareServices(int page = 0, int pageSize = 10, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = MockCloudComputingData.GetSoftwareServices(page, pageSize);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("order-service")]
        public async Task<IActionResult> OrderSoftwareService([FromBody] PursacheServiceRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = MockCloudComputingData.OrderSoftwareService(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("change-service-quantity")]
        public async Task<IActionResult> ChangeSoftwareServiceQuantity([FromBody] ChangeServiceQuantityRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var success = MockCloudComputingData.ChangeSoftwareServiceQuantity(request.SubscriptionId, request.NewQuantity);
                if (success)
                {
                    return Ok("Service quantity changed successfully.");
                }
                else
                {
                    return BadRequest("Failed to change service quantity.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("cancel-service/{subscriptionId}")]
        public async Task<IActionResult> CancelSoftware(Guid subscriptionId, CancellationToken cancellationToken = default)
        {
            try
            {
                var success =  MockCloudComputingData.CancelSoftware(subscriptionId);
                if (success)
                {
                    return Ok("Service canceled successfully.");
                }
                else
                {
                    return BadRequest("Failed to cancel service.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("extend-service-validity")]
        public async Task<IActionResult> ExtendSoftwareValidity([FromBody] ExtendSoftwareValidityRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = MockCloudComputingData.ExtendSoftwareValidity(request.SoftwareId, request.NewValidityDate);
                if (response.IsSuccess)
                {
                    return Ok("Service validity extended successfully.");
                }
                else
                {
                    return BadRequest("Failed to extend service validity.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
