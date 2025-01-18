using AuthService.Entities;
using AuthService.Repositories;
using AuthService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController(LoginUser loginUser) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Get(LoginUser.Request request)
        {
            string jwt = await loginUser.Handle(request);
            return Ok(jwt);
        }
    }
}
