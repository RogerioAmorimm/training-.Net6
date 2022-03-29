
using Confluent.Kafka;
using MediatR;
using Microservices.Dto;
using Microservices.Services.Consumer;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.Queries.Tickets.Handler
{
    public class TicketQueryHandler : IRequestHandler<TicketQuery, TicketDto>
    {
        private readonly IConsumerBuilder<string, string> _consumer;
        public TicketQueryHandler(IConsumerBuilder<string, string> consumer)
        {
            _consumer = consumer;
        }

        public Task<TicketDto> Handle(TicketQuery request, CancellationToken cancellationToken)
        {
            try
            {
                using var consumer = _consumer.GetConsumerByTopic(request.TypeTopic);
                consumer.Subscribe(request.TypeTopic.ToString());
                var message = consumer.Consume(cancellationToken).Message;
                var dto = JsonConvert.DeserializeObject<TicketDto>(message.Value);
                dto.TypeTopic = request.TypeTopic.ToString();
                return Task.FromResult(dto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
