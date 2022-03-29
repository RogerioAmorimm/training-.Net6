using AutoMapper;
using MediatR;
using Microservices.Command.Tickets;
using Microservices.Dto;
using Microservices.Requests.Api.Controllers.ApiV1.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Microservices.Requests.Api.Controllers.ApiV1.ProducerTicket
{
    [Route("[controller]")]
    //[Authorize(Roles = "producer, admin")]
    public class ProducerTicketController : ApiV1BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProducerTicketController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("producer-ticket")]
        public async Task CreateTicketEventAsync(TicketDto dto)
        {
            var ticketEvent = _mapper.Map<CreateTicketEvent>(dto);
            ticketEvent.UserId = new Guid(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier.ToString())?.Value);
            ticketEvent.UserName = User.Identity.Name;
            await _mediator.Publish(ticketEvent);
        }
    }

}
