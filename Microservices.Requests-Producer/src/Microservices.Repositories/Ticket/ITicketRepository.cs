using Microservices.Domain.Models.Ticket;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.Repositories.Ticket
{
    public interface ITicketRepository
    {
        Task insertAsync(TicketModel ticket);
        Task<IEnumerable<TicketModel>> getAllById(Guid userId);
    }
}
