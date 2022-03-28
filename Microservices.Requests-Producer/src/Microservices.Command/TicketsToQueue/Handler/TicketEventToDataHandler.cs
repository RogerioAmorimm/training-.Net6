

using AutoMapper;
using MediatR;
using Microservices.Domain.Models.Ticket;
using Microservices.Hubs.Ticket;
using Microservices.Queries.TicketQuery;
using Microservices.Repositories.Ticket;
using Microservices.RequestsProducer.Api.Hubs.Ticket;
using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.Command.Tickets.Handler
{
    public class TicketEventToDataHandler : INotificationHandler<CreateTicketEvent>
    {
        private readonly IMapper _mapper;
        private readonly ITicketRepository _repository;
        private readonly IMediator _mediator;
        private readonly IHubContext<TicketHub, ITicketHub> _hubContext;

        public TicketEventToDataHandler(IMapper mapper, ITicketRepository repository,
            IMediator mediator, IHubContext<TicketHub, ITicketHub> hubContext)
        {
            _mapper = mapper;
            _repository = repository;
            _mediator = mediator;
            _hubContext = hubContext;
        }

        public async Task Handle(CreateTicketEvent notification, CancellationToken cancellationToken)
        {

            var model = _mapper.Map<TicketModel>(notification);

            await _repository.insertAsync(model);
           
            var result = await _mediator.Send(new TicketsQuery() { UserId = notification.UserId });

            _ = _hubContext.Clients.Groups(notification.UserId.ToString()).ReceivedMessage(result);
          
        }
    }
}

