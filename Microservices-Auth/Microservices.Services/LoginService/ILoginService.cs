
using Microservices.Dtos.UserDto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Microservices.Services.LoginService
{
    public interface ILoginService
    {
        Task<IActionResult> LoginUserAsync(LoginUserDto loginUser);

        Task<IActionResult> RequestResetAsync(RequestResetDto resetDto);

        Task<IActionResult> ResetAsync(ResetDto resetDto);
    }
}
