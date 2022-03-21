using MediatR;
using Microservices.Command.Tickets;
using Microservices.Command.Tickets.Handler;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Infrastructure.IoC
{
    public static class CommandsIoC
    {
        public static void RegisterCommands(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<CreateTicketEvent>, TicketEventToQueueHandler>();
            services.AddScoped<INotificationHandler<CreateTicketEvent>, TicketEventToDataHandler>();

        }
    }
}