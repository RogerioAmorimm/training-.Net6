using Microservices.Services.Consumer;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Infrastructure.IoC
{
    public static class ServicesIoc
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IConsumerBuilder<string, string>, ConsumerKafka<string, string>>();
        }
    }
}
