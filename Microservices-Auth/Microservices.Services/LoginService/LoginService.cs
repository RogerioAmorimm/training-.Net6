using FluentValidation;
using Microservices.Domain.Entities.User;
using Microservices.Dtos.UserDto;
using Microservices.Services.SignInManagerService;
using Microservices.Services.TokenService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Services.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly IValidator<LoginUserDto> _loginValidator;
        private readonly ISignInManagerService<CustomIdentityUser> _signInManager;
        private readonly ITokenService _tokenService;

        public LoginService(IValidator<LoginUserDto> loginValidator,
                            ISignInManagerService<CustomIdentityUser> signInManager,
                            ITokenService tokenService)
        {
            _loginValidator = loginValidator;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<IActionResult> LoginUserAsync(LoginUserDto loginUser)
        {

            var validationResult = await _loginValidator.ValidateAsync(loginUser);

            if (!validationResult.IsValid)
                return new UnauthorizedObjectResult(validationResult.Errors.Select(x => x.ErrorMessage).First());

            var result = await _signInManager.PasswordSignInAsync(loginUser.UserName,
                                                                  loginUser.Password,
                                                                  false,
                                                                  false);

            if (!result.Succeeded) return new UnauthorizedObjectResult("Failed to sign in");

            var user = _signInManager
                        .Users
                        .FirstOrDefault(user =>
                                        user.NormalizedUserName == loginUser.UserName.ToUpper());

            var role = (await _signInManager.GetRolesAsync(user)).FirstOrDefault();

            return new OkObjectResult(new { token = _tokenService.CreateToken(user, role).Value });

        }

        public async Task<IActionResult> RequestResetAsync(RequestResetDto resetDto)
        {
            var identityUser = RecoveryUserByEmail(resetDto.Email);
            if (identityUser is not null)
            {
                var recoveryCode = await _signInManager
                                            .GeneratePasswordResetTokenAsync(identityUser);

                return new OkObjectResult( recoveryCode );
            }

            return new BadRequestResult();
        }

        private CustomIdentityUser RecoveryUserByEmail(string email)
            => _signInManager
                .Users
                .FirstOrDefault(x =>
                                x.NormalizedEmail == email.ToUpper());

        public async Task<IActionResult> ResetAsync(ResetDto resetDto)
        {
            var identityUser = RecoveryUserByEmail(resetDto.Email);
            var result = await _signInManager
                                .ResetPasswordAsync(identityUser,
                                                    resetDto.Token,
                                                    resetDto.NewPassword);

            if (result.Succeeded) return new OkResult();

            return new BadRequestResult();

        }
    }
}
