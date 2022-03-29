

using Confluent.Kafka;
using Microservices.Dto;
using Microservices.Queries.Tickets;
using Microservices.Queries.Tickets.Handler;
using Microservices.Services.Consumer;
using Moq;
using Newtonsoft.Json;
using System.Threading;
using Xunit;

namespace Microservices.Queries.test.Tickets
{
    public class TicketQueryTest
    {
        private readonly Mock<IConsumerBuilder<string, string>> mockConsumer;
        private readonly Mock<IConsumer<string, string>> mockConsumerKafka;
        private readonly TicketQueryHandler service;
        private readonly ConsumeResult<string, string> consumeResult = new ConsumeResult<string, string>() { Message = new Message<string, string>() { Key = "1", Value = JsonConvert.SerializeObject(new TicketDto() { UserName = "teste" }) } };
        private readonly TicketQuery ticketQuery = new TicketQuery() { TypeTopic = Topic.Ti };
        public TicketQueryTest()
        {
            mockConsumer = new Mock<IConsumerBuilder<string, string>>();
            mockConsumerKafka = new Mock<IConsumer<string, string>>();
            service = new TicketQueryHandler(mockConsumer.Object);
        }

        [Fact(DisplayName = "Get tickets by query")]
        [Trait("Type", "Unit")]
        public async void TicketQuery()
        {
            mockConsumer.Setup(x => x.GetConsumerByTopic(It.IsAny<Topic>()))
                .Returns(mockConsumerKafka.Object).Verifiable();

            mockConsumerKafka.Setup(x => x.Subscribe(It.IsAny<string>()))
                .Verifiable();

            mockConsumerKafka.Setup(x => x.Consume(It.IsAny<CancellationToken>()))
                .Returns(consumeResult)
                .Verifiable();

            var result = await service.Handle(ticketQuery, default);
            mockConsumer.Verify();
            mockConsumerKafka.Verify();
            Assert.NotNull(result);
        }

    }
}
