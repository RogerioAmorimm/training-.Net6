using AutoMapper;
using Microservices.Application;
using Microservices.Infrastructure.IoC;
using Microservices.Requests.Api.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Requests.Api
{
    public static class IoC
    {
        public static void Register(IServiceCollection services)
        {
            RepositorysIoC.RegisterRepositorys(services);
            CommandsIoC.RegisterCommands(services);
            RegisterServices(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            //services.AddScoped<IDevOpsServices, DevOpsServices>();
            services.AddSingleton(x => GetMapper());
        }

        private static IMapper GetMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<ApiMapperProfile>();
                x.AddProfile<ApplicationMapperProfile>();
            });

            return config.CreateMapper();
        }
    }
}
