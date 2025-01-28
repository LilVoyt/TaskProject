using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace AdminService.Controllers
{
    [ApiController]
    [Route("admin")]
    public class AdminController(IPublishEndpoint publishEndpoint) : ControllerBase
    {
        [HttpPost("change-role")]
        public async Task<IActionResult> ChangeRole(ChangeRoleRequest request)
        {
            var message = new UserRoleChanged
            {
                UserId = request.UserId,
                NewRole = request.NewRole
            };

            await publishEndpoint.Publish(message);
            return Ok("Role change requested");
        }
    }
}
public record ChangeRoleRequest(Guid UserId, string NewRole);
