using Microservices.Application.Dtos;
using Microservices.Application.Services.Interfaces;
using Microservices.Domain.Commands;
using Microservices.Domain.Repositorys;
using MediatR;

namespace Microservices.Application.Services
{
    public class ColaboradorCommandsServices : IColaboradorCommandsServices
    {
        private readonly IMediator _mediator;
        private readonly IColaboradorRepository _repositorio;

        public ColaboradorCommandsServices(IMediator mediator, IColaboradorRepository repositorio)
        {
            _mediator = mediator;
            _repositorio = repositorio;
        }

        public void AtualizarNomeDoColaborador(ColaboradorDto dto)
        {
            // Commands não retornam dados, apenas modificam a base. Podemos retornar booleano de sucesso ou falha. Usar EF Core preferencialmente
            //dto para command;
            _mediator.Send(new AlterarNomeDoColaboradorCommand(dto.Id, dto.Nome, dto.DataDeNascimento, dto.GanhaSalario));
        }
    }
}