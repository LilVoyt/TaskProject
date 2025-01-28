using AuthService.Services;
using AuthService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public ILoginUser LoginUser { get; set; }
        public IRegisterUser RegisterUser { get; set; }
        public AuthController(ILoginUser loginUser, IRegisterUser registerUser)
        {
            LoginUser = loginUser;
            RegisterUser = registerUser;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            string jwt = await LoginUser.Handle(request);
            return Ok(jwt);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request) //here is problems with a roles while saving
        {
            string jwt = await RegisterUser.Handle(request);
            return Ok(jwt); 
        }

    }
}
