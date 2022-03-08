
using FluentValidation;
using Microservices.Dtos.UserDto;
using Microservices.Validators.UserValidator;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Ioc
{
    public static class IocValidators
    {
        public static void Registe(IServiceCollection services) 
        {
            services.AddScoped<IValidator<CreateUserDto>, CreateUserValidator>();
            services.AddScoped<IValidator<LoginUserDto>, LoginUserValidator>();
        }
    }
}
