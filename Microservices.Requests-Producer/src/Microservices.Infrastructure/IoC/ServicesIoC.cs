using Microservices.Data.Context;
using Microservices.Repositories.Ticket;
using Microservices.Service.Producer;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Infrastructure.IoC
{
    public static class ServicesIoC
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IProducerKafka, ProducerKafka>();
        }
    }
}