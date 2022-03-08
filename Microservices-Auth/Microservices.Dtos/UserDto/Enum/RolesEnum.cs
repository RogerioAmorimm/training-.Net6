using System.ComponentModel;

namespace Microservices.Dtos.UserDto.Enum
{
    public enum Roles : int
    {
        [Description("Client")]
        client = 1,
        [Description("Sellet")]
        seller
    }

}
