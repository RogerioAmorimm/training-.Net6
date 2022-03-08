
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Services.SignInManagerService
{
    public interface ISignInManagerService<T>
    {
        Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
        IQueryable<T> Users { get; }
        Task<IList<string>> GetRolesAsync(T user);
        Task<string> GeneratePasswordResetTokenAsync(T user);
        Task<IdentityResult> ResetPasswordAsync(T user, string token, string newPassword);
        Task SignOutAsync();
    }
}
