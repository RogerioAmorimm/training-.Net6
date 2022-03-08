
using Microservices.Dtos.Base;

namespace Microservices.Dtos.UserDto
{
    public class ResetDto : BaseDto
    {
        public string NewPassword { get; set; }
        public string RePassword { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

    }
}
