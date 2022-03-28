

using Microservices.Domain.Models.Base;
using Microservices.Dto;
using System;

namespace Microservices.Domain.Models.Ticket
{
    public class TicketModel : BaseModel
    {
        public string Description { get; private set; }
        public string TypeTopic { get; private set; }
        public Guid UserId { get; private set; }
        public string UserName { get; private set; }
    }
}
