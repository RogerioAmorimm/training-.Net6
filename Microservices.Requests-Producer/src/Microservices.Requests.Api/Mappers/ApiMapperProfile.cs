using AutoMapper;
using Microservices.Command.Tickets;
using Microservices.Dto;
using Microservices.Dto.Messages;
using Microservices.Requests.Api.Controllers.ApiV1.ProducerTicket;

namespace Microservices.Requests.Api.Mappers
{
    public class ApiMapperProfile : Profile
    {
        public ApiMapperProfile()
        { 
              CreateMap<TicketDto, CreateTicketEvent>();
                CreateMap<CreateTicketEvent, TicketMessage>();
        }
    }
}
