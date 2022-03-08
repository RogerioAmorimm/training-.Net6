using FluentValidation;
using FluentValidation.Results;
using Microservices.Dtos.UserDto;
using Microservices.Repositories.UserRepository;
using Moq;
using System.Collections.Generic;
using Xunit;
namespace Microservices.Services.Test.RegisterTest
{
    public class RegisterServiceTest
    {
        private readonly Mock<IUserRepository> _mockRepository;
        private readonly Mock<IValidator<CreateUserDto>> _mockCreateValidator;
        private readonly RegisterService.RegisterService _service;

        public RegisterServiceTest()
        {
            _mockCreateValidator = new Mock<IValidator<CreateUserDto>>();
            _mockRepository = new Mock<IUserRepository>();
            _service = new RegisterService.RegisterService(_mockRepository.Object, _mockCreateValidator.Object);
        }
        [Fact(DisplayName = "Create new user successfully")]
        public async void CreateUserAsyncWithSuccess()
        {
            _mockCreateValidator.Setup(x => x.ValidateAsync(It.IsAny<CreateUserDto>(), default))
                                .ReturnsAsync(new ValidationResult())
                                .Verifiable();
            _mockRepository.Setup(x => x.CreateUserAysnc(It.IsAny<CreateUserDto>()))
                            .ReturnsAsync(new CreateUserDto())
                            .Verifiable();

            var result = await _service.CreateUserAsync(It.IsNotNull<CreateUserDto>());
            _mockCreateValidator.Verify();
            _mockRepository.Verify();
            Assert.NotNull(result);
            Assert.True(result.Erros.Count == 0);

        }
        [Fact(DisplayName = "Create new user unsuccessfully because of the DTO validation")]
        public async void CreateUserAsyncWithOutSuccess()
        {
            var erroMessageRole = "Role can't be null";
            var erroMessageEmail = "Email can't be null";
            var erroMessagePassword = "Password can't be null";
            var listOfErrors = new List<string>() { erroMessageRole, erroMessageEmail, erroMessagePassword };
            _mockCreateValidator.Setup(x => x.ValidateAsync(It.IsAny<CreateUserDto>(), default))
                               .ReturnsAsync(new ValidationResult(new List<ValidationFailure>()
                                                                    {
                                                                        new(nameof(CreateUserDto.Email), erroMessageEmail),
                                                                        new(nameof(CreateUserDto.Role), erroMessageRole),
                                                                        new(nameof(CreateUserDto.Password), erroMessagePassword)
                                                                    }
                                            )
                               )
                               .Verifiable();

            var result = await _service.CreateUserAsync(new CreateUserDto());
            _mockCreateValidator.Verify();

            Assert.NotNull(result);
            Assert.True(result.Erros.Count == 3);
            Assert.Contains(result.Erros, x => listOfErrors.Contains(x));

        }
    }
}
