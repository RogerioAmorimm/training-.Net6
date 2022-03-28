
using Microservices.Dtos.UserDto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Microservices.Services.RegisterService
{
    public interface IRegisterService
    {
        Task<IActionResult> CreateUserAsync(CreateUserDto userDto);
    }
}
