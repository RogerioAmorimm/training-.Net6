using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Hubs.Providers
{
    public static class UserProvides
    {
        public static string GetId(this ClaimsPrincipal claims) 
        {
            string value = claims.FindFirst(ClaimTypes.NameIdentifier).Value;
            return value;
        }
    }
}
