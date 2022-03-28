

using Confluent.Kafka;
using Microservices.Dto;
using Microsoft.Extensions.Configuration;

namespace Microservices.Services.Consumer
{
    public class ConsumerKafka<TKey, TValue> : IConsumerBuilder<TKey, TValue>
    {
        private readonly IConfiguration _config;

        public ConsumerKafka(IConfiguration config)
        {
            _config = config;
        }

        public IConsumer<TKey, TValue> getConsumerByTopic(Topic typeTopic)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = _config.GetSection("Kafka:Host").Value,
                GroupId = $"{typeTopic}-group-0",
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoOffsetStore =false

            };

            return new ConsumerBuilder<TKey, TValue>(config).Build();

        }
    }
}
