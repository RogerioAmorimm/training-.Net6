

using Microservices.Domain.Models.Ticket;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.Hubs.Ticket
{
    public interface ITicketHub
    {
        Task ReceivedMessage(IEnumerable<TicketModel> tickets);
    }
}
