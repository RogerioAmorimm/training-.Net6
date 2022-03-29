

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

        public TicketEventToDataHandler(IMapper mapper, ITicketRepository repository,
            IMediator mediator)
        {
            _mapper = mapper;
            _repository = repository;
            _mediator = mediator;
        }

        public async Task Handle(CreateTicketEvent notification, CancellationToken cancellationToken)
        {

            var model = _mapper.Map<TicketModel>(notification);

            await _repository.insertAsync(model);
           
            var result = await _mediator.Send(new TicketsQuery() { UserId = notification.UserId });
          
        }
    }
}

