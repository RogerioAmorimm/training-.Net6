

using Microsoft.AspNetCore.Identity;
using System;

namespace Microservices.Domain.Entities.User
{
    public class CustomIdentityUser : IdentityUser<Guid>
    {
    }
}
