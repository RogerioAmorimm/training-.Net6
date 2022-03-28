using Confluent.Kafka;
using Microservices.Dto;
using Microservices.Services.Consumer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;

namespace Microservices.Requests.Api.Controllers.ApiV1.ConsumerTicket
{
    [Authorize(Roles = "consumer, admin")]
    public class TicketHub : Hub
    {

        private readonly IConsumerBuilder<string, string> _consumer;

        public TicketHub(IConsumerBuilder<string, string> consumer)
        {
            _consumer = consumer;
        }
        
        public async IAsyncEnumerable<TicketDto> ListenTickets(Topic typeTopic, CancellationToken cancellationToken)
        {
            using var consumer = _consumer.getConsumerByTopic(typeTopic);
            consumer.Subscribe(typeTopic.ToString());
            while (!cancellationToken.IsCancellationRequested) 
            {
                var message = consumer.Consume(cancellationToken).Message;
                var dto = JsonConvert.DeserializeObject<TicketDto>(message.Value);
                dto.TypeTopic = typeTopic.ToString();
                yield return dto;
            }

        }
    }
}
