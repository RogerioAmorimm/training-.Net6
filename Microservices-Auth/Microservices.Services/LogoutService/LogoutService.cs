

using Microservices.Domain.Entities.User;
using Microservices.Services.SignInManagerService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Microservices.Services.LogoutService
{
    public class LogoutService : ILogoutService
    {
        private readonly ISignInManagerService<CustomIdentityUser> _signinManager;

        public LogoutService(ISignInManagerService<CustomIdentityUser> signinManager)
        {
            _signinManager = signinManager;
        }

        public async Task LogoutAsync()
            => await _signinManager.SignOutAsync();


    }
}
