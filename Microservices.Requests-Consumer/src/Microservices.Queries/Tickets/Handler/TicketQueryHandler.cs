
using Confluent.Kafka;
using MediatR;
using Microservices.Dto;
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
        private readonly IConfiguration _config;

        public TicketQueryHandler(IConfiguration config)
        {
            _config = config;
        }

        public Task<TicketDto> Handle(TicketQuery request, CancellationToken cancellationToken)
        {
            try
            {
             
                
                var config = new ConsumerConfig
                {
                    BootstrapServers = _config.GetSection("Kafka:Host").Value,
                    GroupId = $"{request.TypeTopic}-group-0",
                    AutoOffsetReset = AutoOffsetReset.Earliest,
                };

                using var consumer = new ConsumerBuilder<string, string>(config).Build();
                consumer.Subscribe(request.TypeTopic.ToString());
                var message = consumer.Consume(cancellationToken).Message;
                var dto = JsonConvert.DeserializeObject<TicketDto>(message.Value);
                dto.TypeTopic = request.TypeTopic;
                return Task.FromResult(dto);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
