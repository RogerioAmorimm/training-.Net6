
using Microservices.Dtos.UserDto;
using Microservices.Services.LoginService;
using Microservices_Auth.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Microservices_Auth.Controllers
{
    [Route("[controller]")]
    public class LoginController : ApiBaseController
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> LoginUserAsync(LoginUserDto loginUser)
            => await _loginService.LoginUserAsync(loginUser);
        
        [HttpPost("/Request-reset")]
        public async Task<IActionResult> RequestResetAsync(RequestResetDto resetDto)
            => await _loginService.RequestResetAsync(resetDto);
        
        [HttpPost("/Reset")]
        public async Task<IActionResult> ResetAsync(ResetDto resetDto)
            => await _loginService.ResetAsync(resetDto);

    }
}
