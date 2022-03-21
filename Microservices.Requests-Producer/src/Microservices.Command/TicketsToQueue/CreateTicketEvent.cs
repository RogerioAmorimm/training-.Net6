
using MediatR;
using Microservices.Dto;

namespace Microservices.Command.Tickets
{
    public class CreateTicketEvent : INotification
    {
        public Topic TypeTopic { get; private set; }
        public string Description { get; private set; }
        public string UserName { get; private set; }
    }
}
