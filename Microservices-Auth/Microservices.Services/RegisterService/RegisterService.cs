
using AutoMapper;
using FluentValidation;
using Microservices.Dtos.UserDto;
using Microservices.Repositories.UserRepository;
using Microservices.Services.LoginService;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Microservices.Services.RegisterService
{
    public class RegisterService : IRegisterService
    {
        private readonly IUserRepository _repository;
        private readonly IValidator<CreateUserDto> _createValidator;
        private readonly IMapper _mapper;
        private readonly ILoginService _loginService;

        public RegisterService(IUserRepository repository,
                               IValidator<CreateUserDto> createValidator,
                               IMapper mapper, ILoginService loginService)
        {
            _repository = repository;
            _createValidator = createValidator;
            _mapper = mapper;
            _loginService = loginService;
        }

        public async Task<IActionResult> CreateUserAsync(CreateUserDto userDto)
        {
            var validationResult = await _createValidator.ValidateAsync(userDto);
            
            if (!validationResult.IsValid)
            {
                return new ObjectResult(validationResult.Errors.Select(x=>x.ErrorMessage)) {
                    StatusCode = (int)HttpStatusCode.PartialContent
                };
            }

            var newUser = await _repository.CreateUserAysnc(userDto);

            return await _loginService.LoginUserAsync(_mapper.Map<LoginUserDto>(newUser));
        }
    }
}
