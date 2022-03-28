using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microservices.Dtos.UserDto;
using Microservices.Repositories.UserRepository;
using Microservices.Services.LoginService;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;
namespace Microservices.Services.Test.RegisterTest
{
    public class RegisterServiceTest
    {
        private readonly Mock<IUserRepository> _mockRepository;
        private readonly Mock<IValidator<CreateUserDto>> _mockCreateValidator;
        private readonly Mock<ILoginService> _mockLoginService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly RegisterService.RegisterService _service;
        public RegisterServiceTest()
        {
            _mockCreateValidator = new Mock<IValidator<CreateUserDto>>();
            _mockRepository = new Mock<IUserRepository>();
            _mockLoginService = new Mock<ILoginService>();
            _mockMapper = new Mock<IMapper>();
            _service = new RegisterService.RegisterService(_mockRepository.Object,
                _mockCreateValidator.Object, _mockMapper.Object, _mockLoginService.Object);
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
            _mockMapper.Setup(x => x.Map<LoginUserDto>(It.IsAny<CreateUserDto>()))
               .Returns(new LoginUserDto()).Verifiable();

            _mockLoginService.Setup(x => x.LoginUserAsync(It.IsAny<LoginUserDto>()))
                .ReturnsAsync(new OkObjectResult(new LoginResultDto())).Verifiable();

            var result = await _service.CreateUserAsync(It.IsNotNull<CreateUserDto>());
            var obj = (result as OkObjectResult).Value as LoginResultDto;
            _mockCreateValidator.Verify();
            _mockRepository.Verify();
            _mockMapper.Verify();
            _mockLoginService.Verify();

            Assert.NotNull(result);
            Assert.True(obj.Erros.Count == 0);

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
            var obj = (result as ObjectResult).Value as IEnumerable<object>;
            _mockCreateValidator.Verify();
            
            Assert.NotNull(result);
            Assert.True(obj.Count() == 3);

        }
    }
}
