
using Microservices.Data.Context;
using Microservices.Domain.Models.Ticket;
using Microservices.Repositories.Ticket;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

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

        [Fact(DisplayName = "Insert ticket to data")]
        [Trait("Type", "Unit")]
        public async void SendTicketToData()
        {
            _mockContext.Setup(x => x.Tickets.InsertOneAsync(It.IsAny<TicketModel>(), default, default))
                .Returns(Task.CompletedTask).Verifiable();

            await service.InsertAsync(It.IsAny<TicketModel>());

            _mockContext.Verify();

        }
   

    }
}
