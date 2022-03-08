

using Microservices.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Services.SignInManagerService
{
    public class SignInManagerService : ISignInManagerService<CustomIdentityUser>
    {

        private readonly SignInManager<CustomIdentityUser> _signInManager;

        public SignInManagerService(SignInManager<CustomIdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IQueryable<CustomIdentityUser> Users => _signInManager.UserManager.Users;

        public Task<string> GeneratePasswordResetTokenAsync(CustomIdentityUser user)
            => _signInManager.UserManager.GeneratePasswordResetTokenAsync(user);

        public Task<IList<string>> GetRolesAsync(CustomIdentityUser user)
            => _signInManager.UserManager.GetRolesAsync(user);

        public Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
            => _signInManager.PasswordSignInAsync(userName: userName, password: password,
                                                  isPersistent: isPersistent, lockoutOnFailure: lockoutOnFailure);

        public Task<IdentityResult> ResetPasswordAsync(CustomIdentityUser user, string token, string newPassword)
            => _signInManager.UserManager.ResetPasswordAsync(user, token, newPassword);

        public Task SignOutAsync() => _signInManager.SignOutAsync();

    }
}
