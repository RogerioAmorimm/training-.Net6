
using MediatR;
using Microservices.RequestsProducer.Api.Hubs.Ticket;
using Moq;

namespace Microservices.Hubs.Test.TicketHubTest
{
    public class TicketHubTest
    {
        private readonly Mock<IMediator> _mockMediator;
        private readonly TicketHub service;
        public TicketHubTest()
        {
            _mockMediator = new Mock<IMediator>();
            service = new TicketHub(_mockMediator.Object);

        }

    }
}
