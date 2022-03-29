

using Confluent.Kafka;

namespace Microservices.Service.Producer
{
    public interface IProducerKafka
    {
        IProducer<TKey, TValue> GetProducer<TKey, TValue>();
    }
}
