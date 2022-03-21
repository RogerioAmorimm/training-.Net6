
using Microservices.Dto.Base;

namespace Microservices.Dto
{
    public class TicketDto : BaseDto
    {
        public Topic TypeTopic { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
    }
}
