
using Microservices.Dtos.Base;

namespace Microservices.Dtos.UserDto
{
    public class LoginUserDto : BaseDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
