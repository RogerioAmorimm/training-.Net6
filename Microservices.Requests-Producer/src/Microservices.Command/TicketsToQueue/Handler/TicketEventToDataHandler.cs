

using Confluent.Kafka;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.Command.Tickets.Handler
{
    public class TicketEventToDataHandler : INotificationHandler<CreateTicketEvent>
    {

        public TicketEventToDataHandler()
        {
        }

        public Task Handle(CreateTicketEvent notification, CancellationToken cancellationToken)
        {
            // mandar para o banco
            return Task.CompletedTask;
        }
    }
}

