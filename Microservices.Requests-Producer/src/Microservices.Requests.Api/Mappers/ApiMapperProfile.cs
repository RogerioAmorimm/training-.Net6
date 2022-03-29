using AutoMapper;
using Confluent.Kafka;
using Microservices.Command.Tickets;
using Microservices.Domain.Models.Ticket;
using Microservices.Dto;
using Microservices.Dto.Messages;
using Microservices.Requests.Api.Controllers.ApiV1.ProducerTicket;
using System;

namespace Microservices.Requests.Api.Mappers
{
    public class ApiMapperProfile : Profile
    {
        public ApiMapperProfile()
        {
            CreateMap<TicketDto, CreateTicketEvent>();
            CreateMap<CreateTicketEvent, TicketMessage>();
            CreateMap<CreateTicketEvent, TicketModel>();
            CreateMap<string, Message<string, string>>()
                .ForMember(x=>x.Value, y=>y.MapFrom(z=>z))
                .ForMember(x=>x.Key, y=>y.Ignore());
        }
    }
}
