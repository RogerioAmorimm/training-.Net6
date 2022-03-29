
using Microservices.Data.Context;
using Microservices.Repositories.Ticket;
using Moq;

namespace Microservices.Repositories.Test.Ticket
{
    public class TicketRepositoryTest
    {

        private readonly Mock<IProducerContext> _mockContext;
        private readonly TicketRepository service;
        public TicketRepositoryTest()
        {
            _mockContext = new Mock<IProducerContext>();
            service = new TicketRepository(_mockContext.Object);
        }

    }
}
