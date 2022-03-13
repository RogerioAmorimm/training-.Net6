using AutoMapper;
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
        private readonly IMapper _mapper;

        public LoginService(IValidator<LoginUserDto> loginValidator,
                            ISignInManagerService<CustomIdentityUser> signInManager,
                            ITokenService tokenService, IMapper mapper)
        {
            _loginValidator = loginValidator;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<IActionResult> LoginUserAsync(LoginUserDto loginUser)
        {
            
            var validationResult = await _loginValidator.ValidateAsync(loginUser);


            if (!validationResult.IsValid)
                return new UnauthorizedObjectResult(validationResult.Errors.Select(x => x.ErrorMessage).First());

            var user = _signInManager.Users.FirstOrDefault(x => x.Email.Equals(loginUser.Email));
            
            if(user is null)
                return new UnauthorizedObjectResult("Failed to sign in, Invalid User");
            
            var result = await _signInManager.PasswordSignInAsync(user.UserName,
                                                                  loginUser.Password,
                                                                  false,
                                                                  false);

            if (!result.Succeeded) return new UnauthorizedObjectResult("Failed to sign in");

            var role = (await _signInManager.GetRolesAsync(user)).FirstOrDefault();

            return new OkObjectResult(new LoginResultDto {Token=_tokenService.CreateToken(user, role).Value,
                                                          User = _mapper.Map<UserDto>(user)});

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
