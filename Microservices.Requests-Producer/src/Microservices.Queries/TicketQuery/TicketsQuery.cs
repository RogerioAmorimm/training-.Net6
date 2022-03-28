
using MediatR;
using Microservices.Domain.Models.Ticket;
using System;
using System.Collections.Generic;

namespace Microservices.Queries.TicketQuery
{
    public class TicketsQuery : IRequest<IEnumerable<TicketModel>>
    {
        public Guid UserId{ get; set; }
    }
}
