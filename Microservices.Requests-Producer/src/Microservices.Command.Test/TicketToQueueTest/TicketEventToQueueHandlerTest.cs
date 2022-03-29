

using AutoMapper;
using Confluent.Kafka;
using Microservices.Command.Tickets;
using Microservices.Command.Tickets.Handler;
using Microservices.Dto.Messages;
using Microservices.Service.Producer;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Microservices.Command.Test.TicketToQueueTest
{
    public class TicketEventToQueueHandlerTest
    {
        private readonly Mock<IProducerKafka> _mockProducerKafka;
        private readonly Mock<IProducer<string, string>> _mockProducer;
        private readonly Mock<IMapper> _mockMapper;
        private readonly TicketEventToQueueHandler service;
        private readonly CreateTicketEvent createTicketEvent = new CreateTicketEvent();

        public TicketEventToQueueHandlerTest()
        {
            _mockProducerKafka = new Mock<IProducerKafka>();
            _mockProducer = new Mock<IProducer<string, string>>();
            _mockMapper = new Mock<IMapper>();
            service = new TicketEventToQueueHandler(_mockMapper.Object, _mockProducerKafka.Object);
        }

        [Fact(DisplayName = "Send tickets to mq")]
        [Trait("Type", "Unit")]
        public async void TicketsToData()
        {
            _mockProducerKafka.Setup(x => x.GetProducer<string, string>())
                .Returns(_mockProducer.Object).Verifiable();

            _mockMapper.Setup(x => x.Map<TicketMessage>(It.IsAny<CreateTicketEvent>()))
               .Returns(new TicketMessage()).Verifiable();

            _mockMapper.Setup(x => x.Map<Message<string, string>>(It.IsAny<string>()))
               .Returns(new Message<string, string>()).Verifiable();

            _mockProducer.Setup(x => x.ProduceAsync(It.IsAny<string>(), It.IsAny<Message<string, string>>(), default))
                .Returns(It.IsAny<Task<DeliveryResult<string, string>>>())
                .Verifiable();


            await service.Handle(createTicketEvent, default);

            _mockMapper.Verify();
        }
    }
}
