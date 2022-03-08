
using Microservices.Services.LogoutService;
using Microservices_Auth.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Microservices_Auth.Controllers
{
    [Route("[controller]")]
    public class LogoutController : ApiBaseController
    {
        private readonly ILogoutService _logoutService;

        public LogoutController(ILogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpGet]
        public async Task LogoutUserAsync()
            => await _logoutService.LogoutAsync();

    }
}
