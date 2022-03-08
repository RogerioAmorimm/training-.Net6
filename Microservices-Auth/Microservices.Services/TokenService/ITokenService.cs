

using Microservices.Domain.Entities.Token;
using Microservices.Domain.Entities.User;

namespace Microservices.Services.TokenService
{
    public interface ITokenService
    {
        Token CreateToken(CustomIdentityUser user, string role);
    }
}
