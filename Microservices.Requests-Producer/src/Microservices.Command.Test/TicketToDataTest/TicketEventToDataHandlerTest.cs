

using AutoMapper;
using MediatR;
using Microservices.Command.Tickets;
using Microservices.Command.Tickets.Handler;
using Microservices.Domain.Models.Ticket;
using Microservices.Hubs.Ticket;
using Microservices.Queries.TicketQuery;
using Microservices.Repositories.Ticket;
using Microservices.RequestsProducer.Api.Hubs.Ticket;
using Microsoft.AspNetCore.SignalR;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microservices.Command.Test.TicketToDataTest
{
    public class TicketEventToDataHandlerTest
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ITicketRepository> _mockRepository;
        private readonly Mock<IMediator> _mockMediator;
        private readonly CreateTicketEvent createTicketEvent = new CreateTicketEvent();

        private readonly TicketEventToDataHandler service;
        public TicketEventToDataHandlerTest()
        {
            _mockMapper = new Mock<IMapper>();
            _mockRepository = new Mock<ITicketRepository>();
            _mockMediator = new Mock<IMediator>();
            service = new TicketEventToDataHandler(_mockMapper.Object, _mockRepository.Object, _mockMediator.Object);
        }

        [Fact(DisplayName = "Send tickets to data")]
        [Trait("Type", "Unit")]
        public async void TicketsToData() 
        {
            _mockMapper.Setup(x => x.Map<TicketModel>(It.IsAny<CreateTicketEvent>()))
                .Returns(It.IsAny<TicketModel>()).Verifiable();
            _mockRepository.Setup(x => x.InsertAsync(It.IsAny<TicketModel>()))
                .Returns(Task.CompletedTask)
                .Verifiable();
            _mockMediator.Setup((x) => x.Send(It.IsAny<TicketsQuery>(), default(CancellationToken)))
                .ReturnsAsync(It.IsAny<IEnumerable<TicketModel>>()).Verifiable();

            await service.Handle(createTicketEvent, default);

            _mockMapper.Verify();
            _mockRepository.Verify();
            _mockMediator.Verify();
        }

    }
}
