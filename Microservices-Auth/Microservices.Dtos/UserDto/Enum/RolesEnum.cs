using System.ComponentModel;

namespace Microservices.Dtos.UserDto.Enum
{
    public enum Roles : int
    {
        [Description("Producer")]
        producer = 1,
        [Description("Consumer")]
        consumer
    }

}
