

using Confluent.Kafka;
using Microservices.Dto;

namespace Microservices.Services.Consumer
{
    public interface IConsumerBuilder<TKey, TValue>
    {
        IConsumer<TKey, TValue> GetConsumerByTopic(Topic typeTopic);
    }
}
