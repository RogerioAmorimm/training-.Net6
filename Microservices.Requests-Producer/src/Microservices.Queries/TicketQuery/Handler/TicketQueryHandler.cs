
using MediatR;
using Microservices.Domain.Models.Ticket;
using Microservices.Repositories.Ticket;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.Queries.TicketQuery.Handler
{
    public class TicketQueryHandler : IRequestHandler<TicketsQuery, IEnumerable<TicketModel>>
    {

        private readonly ITicketRepository _repository;

        public TicketQueryHandler(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TicketModel>> Handle(TicketsQuery request, CancellationToken cancellationToken)
            => await _repository.getAllById(request.UserId);
    }
}
