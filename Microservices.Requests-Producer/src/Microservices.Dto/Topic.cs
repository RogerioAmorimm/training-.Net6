
using System.ComponentModel;

namespace Microservices.Dto
{
    public enum Topic : int
    {
        [Description("TI")]
        Ti = 1,
        [Description("Email")]
        Email,
        [Description("Other")]
        Other,

    }
}
