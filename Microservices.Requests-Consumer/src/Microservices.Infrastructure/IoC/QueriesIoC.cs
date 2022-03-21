using MediatR;
using Microservices.Dto;
using Microservices.Queries.Tickets;
using Microservices.Queries.Tickets.Handler;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Microservices.Infrastructure.IoC
{
    public static class QueriesIoC
    {
        public static void RegisterCommands(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<TicketQuery, TicketDto>, TicketQueryHandler>();
        }
    }
}