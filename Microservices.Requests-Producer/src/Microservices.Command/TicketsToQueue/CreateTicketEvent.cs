
using MediatR;
using Microservices.Dto;
using System;

namespace Microservices.Command.Tickets
{
    public class CreateTicketEvent : INotification
    {
        public Topic TypeTopic { get;  set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public Guid UserId { get;  set; }


    }
}
