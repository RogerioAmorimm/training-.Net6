
using Microservices.Dtos.Base;

namespace Microservices.Dtos.UserDto
{
    public class LoginUserDto : BaseDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
