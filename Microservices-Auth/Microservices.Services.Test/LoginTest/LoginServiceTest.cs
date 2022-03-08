
using FluentValidation;
using FluentValidation.Results;
using Microservices.Domain.Entities.Token;
using Microservices.Domain.Entities.User;
using Microservices.Dtos.UserDto;
using Microservices.Services.SignInManagerService;
using Microservices.Services.TokenService;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Microservices.Services.Test.LoginTest
{
    public class LoginServiceTest
    {
        private readonly Mock<IValidator<LoginUserDto>> _mockLoginValidator;
        private readonly Mock<ISignInManagerService<CustomIdentityUser>> _mockSignInManager;
        private readonly Mock<ITokenService> _mockTokenService;
        private readonly LoginService.LoginService _mockService;
        private readonly LoginUserDto fakeLoginDto = new() { Password = "123456", UserName = "Name" };
        private readonly List<CustomIdentityUser> fakeCustomIdentityUser = new() { new() { NormalizedUserName = "NAME", NormalizedEmail = "NAME@NAME.COM" } };
        private readonly RequestResetDto fakeRequestResetDto = new() { Email = "name@name.com" };
        private readonly ResetDto fakeResetDto = new() { Email = "name@name.com", NewPassword = "123456", RePassword = "123456" };
        public LoginServiceTest()
        {
            _mockLoginValidator = new Mock<IValidator<LoginUserDto>>();
            _mockSignInManager = new Mock<ISignInManagerService<CustomIdentityUser>>();
            _mockTokenService = new Mock<ITokenService>();
            _mockService = new LoginService.LoginService(_mockLoginValidator.Object, _mockSignInManager.Object, _mockTokenService.Object);
        }

        [Fact(DisplayName = "Login successfully")]
        public async void LoginWithSuccess()
        {

            _mockLoginValidator.Setup(x => x.ValidateAsync(It.IsAny<LoginUserDto>(), default))
                                .ReturnsAsync(new ValidationResult()).Verifiable();

            _mockSignInManager.Setup(x => x.PasswordSignInAsync(It.IsAny<string>(),
                                                                It.IsAny<string>(),
                                                                It.IsAny<bool>(),
                                                                It.IsAny<bool>()))
                                .ReturnsAsync(SignInResult.Success).Verifiable();

            _mockSignInManager.Setup((s) => s.Users)
                               .Returns(fakeCustomIdentityUser.AsQueryable()).Verifiable();

            _mockSignInManager.Setup(x => x.GetRolesAsync(It.IsAny<CustomIdentityUser>()))
                                .ReturnsAsync(new List<string>()).Verifiable();

            _mockTokenService.Setup(x => x.CreateToken(It.IsAny<CustomIdentityUser>(), It.IsAny<string>()))
                                .Returns(new Token(It.IsAny<string>())).Verifiable();


            var result = await _mockService.LoginUserAsync(fakeLoginDto);

            _mockLoginValidator.Verify();
            _mockSignInManager.Verify();
            _mockTokenService.Verify();
            Assert.NotNull(result);
            Assert.True(result.GetType() == typeof(Microsoft.AspNetCore.Mvc.OkObjectResult));
        }
        [Fact(DisplayName = "Login unsuccessful")]
        public async void LoginWithOutSuccess()
        {
            var errorMessage = "Failed to sign in";
            _mockLoginValidator.Setup(x => x.ValidateAsync(It.IsAny<LoginUserDto>(), default))
                                .ReturnsAsync(new ValidationResult()).Verifiable();

            _mockSignInManager.Setup(x => x.PasswordSignInAsync(It.IsAny<string>(),
                                                                It.IsAny<string>(),
                                                                It.IsAny<bool>(),
                                                                It.IsAny<bool>()))
                                .ReturnsAsync(SignInResult.Failed).Verifiable();

            var result = await _mockService.LoginUserAsync(fakeLoginDto);

            _mockSignInManager.Verify();
            _mockLoginValidator.Verify();
            Assert.NotNull(result);
            Assert.True(result.GetType() == typeof(Microsoft.AspNetCore.Mvc.UnauthorizedObjectResult));
            Assert.Equal(errorMessage, ((Microsoft.AspNetCore.Mvc.UnauthorizedObjectResult)result).Value);

        }
        [Fact(DisplayName = "Login unsuccessful because of the DTO validation")]
        public async void LoginWithOutSuccessBeacauseValidation()
        {
            var errorMessageUserName = "UserName can not must be empty";
            var errorMessagePassword = "Password can not must be empty";

            _mockLoginValidator.Setup(x => x.ValidateAsync(It.IsAny<LoginUserDto>(), default))
                                .ReturnsAsync(new ValidationResult(new List<ValidationFailure>()
                                                                   {
                                                                        new (nameof(fakeLoginDto.UserName), errorMessageUserName),
                                                                        new (nameof(fakeLoginDto.Password), errorMessagePassword)
                                                                    }
                                ))
                                .Verifiable();



            var result = await _mockService.LoginUserAsync(fakeLoginDto);

            _mockLoginValidator.Verify();

            Assert.NotNull(result);
            Assert.True(result.GetType() == typeof(Microsoft.AspNetCore.Mvc.UnauthorizedObjectResult));
            Assert.Equal(errorMessageUserName, ((Microsoft.AspNetCore.Mvc.UnauthorizedObjectResult)result).Value);
            Assert.NotEqual(errorMessagePassword, ((Microsoft.AspNetCore.Mvc.UnauthorizedObjectResult)result).Value);
        }
        [Fact(DisplayName = "Successfully request password reset")]
        public async void RequestResetWithSuccess()
        {
            var resultToCompare = It.IsNotNull<string>();

            _mockSignInManager.Setup((s) => s.Users)
                               .Returns(fakeCustomIdentityUser.AsQueryable()).Verifiable();

            _mockSignInManager.Setup((s) => s.GeneratePasswordResetTokenAsync(It.IsAny<CustomIdentityUser>()))
                               .ReturnsAsync(resultToCompare).Verifiable();

            var result = await _mockService.RequestResetAsync(fakeRequestResetDto);

            Assert.NotNull(result);
            Assert.True(result.GetType() == typeof(Microsoft.AspNetCore.Mvc.OkObjectResult));
            Assert.Equal(resultToCompare, ((Microsoft.AspNetCore.Mvc.OkObjectResult)result).Value);

        }
        [Fact(DisplayName = "Make unsuccessful password reset request")]
        public async void RequestResetWithOutSuccess()
        {
            var invalidRequestReset = new RequestResetDto() { Email = "" };
            _mockSignInManager.Setup((s) => s.Users)
                               .Returns(fakeCustomIdentityUser.AsQueryable())
                               .Verifiable();

            var result = await _mockService.RequestResetAsync(invalidRequestReset);

            Assert.NotNull(result);
            Assert.True(result.GetType() == typeof(Microsoft.AspNetCore.Mvc.BadRequestResult));
        }
        [Fact(DisplayName = "Successfully reset password")]
        public async void ResetWithSucess()
        {
            _mockSignInManager.Setup((s) => s.Users)
                               .Returns(fakeCustomIdentityUser.AsQueryable())
                               .Verifiable();

            _mockSignInManager.Setup((s) => s.ResetPasswordAsync(It.IsAny<CustomIdentityUser>(),
                                                                 It.IsAny<string>(),
                                                                 It.IsAny<string>()))
                               .ReturnsAsync(IdentityResult.Success)
                               .Verifiable();

            var result = await _mockService.ResetAsync(fakeResetDto);

            Assert.NotNull(result);
            Assert.True(result.GetType() == typeof(Microsoft.AspNetCore.Mvc.OkResult));
        }
        [Fact(DisplayName = "Unsuccessfully reset password")]
        public async void ResetWithOutSuccess()
        {
            _mockSignInManager.Setup((s) => s.Users)
                               .Returns(fakeCustomIdentityUser.AsQueryable())
                               .Verifiable();

            _mockSignInManager.Setup((s) => s.ResetPasswordAsync(It.IsAny<CustomIdentityUser>(),
                                                                 It.IsAny<string>(),
                                                                 It.IsAny<string>()))
                               .ReturnsAsync(IdentityResult.Failed())
                               .Verifiable();

            var result = await _mockService.ResetAsync(fakeResetDto);

            Assert.NotNull(result);
            Assert.True(result.GetType() == typeof(Microsoft.AspNetCore.Mvc.BadRequestResult));
        }
    }
}
