
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Microservices.Service.Producer
{
    public class ProducerKafka: IProducerKafka
    {

        private readonly IConfiguration _config;

        public ProducerKafka(IConfiguration config)
        {
            _config = config;
        }

        public IProducer<TKey, TValue> GetProducer<TKey, TValue>()
        {
            var producer = new ProducerBuilder<TKey, TValue>(new ProducerConfig()
            {
                BootstrapServers = _config.GetSection("Kafka:Host").Value,
            }).Build();

            return producer;
        }
    }
}
