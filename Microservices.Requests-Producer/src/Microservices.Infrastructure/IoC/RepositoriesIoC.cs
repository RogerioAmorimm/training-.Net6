using Microservices.Data.Context;
using Microservices.Repositories.Ticket;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Infrastructure.IoC
{
    public static class RepositoriesIoC
    {
        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddSingleton<IProducerContext, ProducerContext>();
            services.AddScoped<ITicketRepository, TicketRepository>();
        }
    }
}