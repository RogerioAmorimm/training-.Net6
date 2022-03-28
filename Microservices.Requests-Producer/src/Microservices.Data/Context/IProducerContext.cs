

using Microservices.Domain.Models.Ticket;
using MongoDB.Driver;

namespace Microservices.Data.Context
{
    public interface IProducerContext
    {
        IMongoCollection<TicketModel> Tickets { get; }

        public string GetClientString();
    }
}
