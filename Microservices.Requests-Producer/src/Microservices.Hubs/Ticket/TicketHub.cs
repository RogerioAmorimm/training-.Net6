


using MediatR;
using Microservices.Domain.Models.Ticket;
using Microservices.Hubs.Base;
using Microservices.Hubs.Providers;
using Microservices.Hubs.Ticket;
using Microservices.Queries.TicketQuery;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.RequestsProducer.Api.Hubs.Ticket
{
    [Authorize(Roles = "producer, admin")]
    public class TicketHub: BaseHub<ITicketHub>
    {
        private readonly IMediator _mediator;
        public TicketHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<TicketModel>> GetTicketsAsync() 
       {
            return  await _mediator.Send(new TicketsQuery() { UserId = new Guid(Context.User.GetId()) });
        }

    }
}
