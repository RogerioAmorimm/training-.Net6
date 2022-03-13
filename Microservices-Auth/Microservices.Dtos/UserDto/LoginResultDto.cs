
using Microservices.Dtos.Base;

namespace Microservices.Dtos.UserDto
{
    public class LoginResultDto : BaseDto
    {
        public string Token { get; set; }
        public UserDto User { get; set; }
    }
}
