using AuthService.Services;
using AuthService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController(ILoginUser loginUser) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUser.Request request)
        {
            string jwt = await loginUser.Handle(request);
            return Ok(jwt);
        }

        //[HttpPost("regiser")]
        //public async Task<IActionResult> Register()
        //{

        //}

    }
}
