using AuthService.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController() : ControllerBase
    {
        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
            };
            return Ok(user);
        }
    }
}
