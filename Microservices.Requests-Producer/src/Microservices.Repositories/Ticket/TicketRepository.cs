

using Microservices.Data.Context;
using Microservices.Domain.Models.Ticket;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.Repositories.Ticket
{
    public class TicketRepository : ITicketRepository
    {
        private readonly IProducerContext _context;

        public TicketRepository(IProducerContext context)
        {
            _context = context;
        }

        public async Task insertAsync(TicketModel ticket)
        {
            await _context.Tickets.InsertOneAsync(ticket);
        }
        public async Task<IEnumerable<TicketModel>> getAllById(Guid userId)
            => (await _context.Tickets.FindAsync(x => x.UserId == userId)).ToEnumerable();

    }
}
