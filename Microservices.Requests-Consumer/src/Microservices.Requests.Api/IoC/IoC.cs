using AutoMapper;
using Microservices.Infrastructure.IoC;
using Microservices.Requests.Api.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Requests.Api
{
    public static class IoC
    {
        public static void Register(IServiceCollection services)
        {
            QueriesIoC.RegisterCommands(services);
            ServicesIoc.RegisterServices(services);
            RegisterServices(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton(x => GetMapper());
        }

        private static IMapper GetMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<ApiMapperProfile>();
            });

            return config.CreateMapper();
        }
    }
}
