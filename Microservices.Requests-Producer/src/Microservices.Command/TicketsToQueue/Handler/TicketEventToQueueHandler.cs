

using AutoMapper;
using Confluent.Kafka;
using MediatR;
using Newtonsoft.Json;
using Microservices.Dto.Messages;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microservices.Service.Producer;

namespace Microservices.Command.Tickets.Handler
{
    public class TicketEventToQueueHandler : INotificationHandler<CreateTicketEvent>
    {
        private readonly IProducerKafka _producer;
        private readonly IMapper _mapper;
        public TicketEventToQueueHandler(IMapper mapper, IProducerKafka producer)
        {
            _mapper = mapper;
            _producer = producer;
        }

        public async Task Handle(CreateTicketEvent notification, CancellationToken cancellationToken)
        {
            try
            {
                if (cancellationToken.IsCancellationRequested) return;

                var producer = _producer.GetProducer<string, string>();
                var message = _mapper.Map<TicketMessage>(notification);
                var messageJson = JsonConvert.SerializeObject(message);
                var messatomq = _mapper.Map<Message<string, string>>(messageJson);
                messatomq.Key = Guid.NewGuid().ToString();  
                await producer.ProduceAsync(notification.TypeTopic.ToString(), messatomq);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

