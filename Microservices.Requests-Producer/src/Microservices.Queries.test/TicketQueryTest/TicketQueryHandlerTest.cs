
using Microservices.Domain.Models.Ticket;
using Microservices.Queries.TicketQuery;
using Microservices.Queries.TicketQuery.Handler;
using Microservices.Repositories.Ticket;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Microservices.Queries.Test.TicketQueryTest
{
    public class TicketQueryHandlerTest 
    {
        private readonly Mock<ITicketRepository> _mockRepository;
        private readonly TicketQueryHandler service;
        private readonly TicketsQuery ticketsQuery = new TicketsQuery();
        public TicketQueryHandlerTest()
        {
            _mockRepository = new Mock<ITicketRepository>();
            service = new TicketQueryHandler(_mockRepository.Object);
        }

        [Fact(DisplayName = "Get tickets by query")]
        [Trait("Type", "Unit")]
        public async void GetTicketsByQuery()
        {
            var mockList = new List<TicketModel>();
            _mockRepository.Setup(x => x.GetAllById(It.IsAny<Guid>()))
                .ReturnsAsync(mockList.AsEnumerable()).Verifiable();

            var value = await service.Handle(ticketsQuery, default);

            _mockRepository.Verify();
            Assert.NotNull(value);

        }
    }
}
