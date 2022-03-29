
using Confluent.Kafka;
using Microservices.Dto;
using Microservices.Services.Consumer;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Microservices.Services.test.Consumer
{
    public class ConsumerTest
    {
        private readonly Mock<IConfiguration> mockConfig;
        private readonly ConsumerKafka<string, string> service;
        public ConsumerTest()
        {
            mockConfig = new Mock<IConfiguration>();
            service = new ConsumerKafka<string, string>(mockConfig.Object);
        }

        [Fact(DisplayName = "Get Consumer By Topic With Success")]
        [Trait("Type", "Unit")]
        public  void GetConsumerByTopic()
        {
            mockConfig.Setup(x => x.GetSection(It.IsAny<string>()).Value)
                .Returns(It.IsAny<string>()).Verifiable();

            var value = service.GetConsumerByTopic(It.IsAny<Topic>());
            
            mockConfig.Verify();
            Assert.NotNull(value);
        }
    }
}
