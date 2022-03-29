
using Microservices.Queries.TicketQuery.Handler;
using Microservices.Repositories.Ticket;
using Moq;

namespace Microservices.Queries.Test.TicketQueryTest
{
    public class TicketQueryHandlerTest 
    {
        private readonly Mock<ITicketRepository> _mockRepository;
        private readonly TicketQueryHandler service;
        public TicketQueryHandlerTest()
        {
            _mockRepository = new Mock<ITicketRepository>();
            service = new TicketQueryHandler(_mockRepository.Object);
        }
    }
}
