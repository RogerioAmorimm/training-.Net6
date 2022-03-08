
using AutoMapper;
using FluentValidation;
using Microservices.Dtos.UserDto;
using Microservices.Repositories.UserRepository;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Services.RegisterService
{
    public class RegisterService : IRegisterService
    {
        private readonly IUserRepository _repository;
        private readonly IValidator<CreateUserDto> _createValidator;
   
        public RegisterService(IUserRepository repository, 
                               IValidator<CreateUserDto> createValidator)
        {
            _repository = repository;
            _createValidator = createValidator;
        }

        public async Task<CreateUserDto> CreateUserAsync(CreateUserDto userDto)
        {
            var validationResult = await _createValidator.ValidateAsync(userDto);

            if (!validationResult.IsValid)
            {
                foreach (var erro in validationResult.Errors)
                {
                    userDto.Erros.Add(erro.ErrorMessage);
                }
              
                return userDto;
            }

            return await _repository.CreateUserAysnc(userDto);

        }
    }
}
