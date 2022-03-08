

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Microservices.Services.LogoutService
{
    public interface ILogoutService
    {
        Task LogoutAsync();
    }
}
