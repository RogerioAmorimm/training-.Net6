
using Microservices.Domain.Repositories;
using Microservices.Repositories.UserRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Ioc
{
    public static class IocRepositories
    {
        public static void Register(IServiceCollection services) 
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
