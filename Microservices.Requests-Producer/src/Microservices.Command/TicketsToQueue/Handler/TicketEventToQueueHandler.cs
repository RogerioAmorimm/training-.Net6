

using AutoMapper;
using Confluent.Kafka;
using MediatR;
using Newtonsoft.Json;
using Microservices.Dto.Messages;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.Command.Tickets.Handler
{
    public class TicketEventToQueueHandler : INotificationHandler<CreateTicketEvent>
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public TicketEventToQueueHandler(IConfiguration config, IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
        }

        public async Task Handle(CreateTicketEvent notification, CancellationToken cancellationToken)
        {
            try
            {
                if (cancellationToken.IsCancellationRequested) return;

                using var producer = new ProducerBuilder<string, string>(new ProducerConfig()
                {
                    BootstrapServers = _config.GetSection("Kafka:Host").Value,
                }).Build();


                var message = _mapper.Map<TicketMessage>(notification);
                var messageJson = JsonConvert.SerializeObject(message);
                await producer.ProduceAsync(notification.TypeTopic.ToString(),
                                                   new Message<string, string>()
                                                   {
                                                       Key = Guid.NewGuid().ToString(),
                                                       Value = messageJson
                                                   }
                );
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

