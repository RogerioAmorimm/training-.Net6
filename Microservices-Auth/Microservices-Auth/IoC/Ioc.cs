
using AutoMapper;
using Microservices.Ioc;
using Microservices.Mappers.UserMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices_Auth
{
    public static class Ioc
    {
        public static void Register(IServiceCollection services)
        {
            IocServices.Register(services);
            IocRepositories.Register(services);
            IocValidators.Registe(services);
            services.AddSingleton(_ => GetMapper());
        }
        private static IMapper GetMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<UserProfile>();
            });

            return config.CreateMapper();
        }
    }
}
