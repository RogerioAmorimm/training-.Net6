using AutoMapper;
using MediatR;
using Microservices.Dto;
using Microservices.Queries.Tickets;
using Microservices.Requests.Api.Controllers.ApiV1.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Microservices.Requests.Api.Controllers.ApiV1.ProducerTicket
{
    [Route("[controller]")]
    [Authorize(Roles = "consumer, admin")]
    public class ConsumerTicketController : ApiV1BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ConsumerTicketController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("consumer-ticket")]
        public async Task<IActionResult> CreateTicketEventAsync([FromQuery] Topic topic)
            =>  Ok(await _mediator.Send(new TicketQuery() { TypeTopic = topic }));

    }

}
