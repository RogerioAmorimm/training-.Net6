
using MediatR;
using Microservices.Dto;
using System.Collections.Generic;

namespace Microservices.Queries.Tickets
{
    public class TicketQuery : IRequest<TicketDto>
    {
        public Topic TypeTopic { get; set; }
    }
}
