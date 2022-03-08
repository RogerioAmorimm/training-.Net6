using Microservices.Dtos.Base;
using Microservices.Dtos.UserDto.Enum;

namespace Microservices.Dtos.UserDto
{
    public class CreateUserDto : BaseDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public Roles Role { get; set; }
    }
  
}
