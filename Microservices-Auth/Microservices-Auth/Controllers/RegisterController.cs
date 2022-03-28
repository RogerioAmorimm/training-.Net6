
using Microservices.Dtos.UserDto;
using Microservices.Services.RegisterService;
using Microservices_Auth.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Microservices_Auth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ApiBaseController
    {
        private readonly IRegisterService _service;

        public RegisterController(IRegisterService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUserAysync(CreateUserDto newUser) 
        {
            var result = await _service.CreateUserAsync(newUser);
            return result;
        }
    }
}
