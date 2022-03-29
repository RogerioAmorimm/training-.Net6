
using MediatR;
using Microservices.Domain.Models.Ticket;
using Microservices.Queries.TicketQuery;
using Microservices.RequestsProducer.Api.Hubs.Ticket;
using Moq;
using System.Collections.Generic;
using Xunit;

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

        [Fact(DisplayName = "Send tickets to users")]
        [Trait("Type", "Unit")]
        public async void GetTicketsAsync()
        {
            _mockMediator.Setup(x => x.Send(It.IsAny<TicketsQuery>(), default))
                .ReturnsAsync(It.IsAny<IEnumerable<TicketModel>>).Verifiable();

            var value = await service.GetTicketsAsync();
            _mockMediator.Verify();
            Assert.NotNull(value);

        }
      

    }
}
