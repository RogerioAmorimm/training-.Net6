
using Microservices.Dtos.UserDto;
using System.Threading.Tasks;

namespace Microservices.Services.RegisterService
{
    public interface IRegisterService
    {
        Task<CreateUserDto> CreateUserAsync(CreateUserDto userDto);
    }
}
