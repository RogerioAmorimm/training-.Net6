using MediatR;
using Microservices.Domain.Models.Ticket;
using Microservices.Queries.TicketQuery;
using Microservices.Queries.TicketQuery.Handler;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Microservices.Infrastructure.IoC
{
    public static class QueriesIoC
    {
        public static void RegisterQueries(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<TicketsQuery, IEnumerable<TicketModel>>, TicketQueryHandler>();
        }
    }
}