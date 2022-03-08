using Microservices.Domain.AggregatesModel;
using Microservices.Domain.Commands;
using Microservices.Domain.Repositorys;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.Domain.CommandHandllers
{
    public class AlterarNomeDoColaboradorCommandHandler : IRequestHandler<AlterarNomeDoColaboradorCommand, bool>
    {
        private readonly IColaboradorRepository _repositorio;

        public AlterarNomeDoColaboradorCommandHandler(IColaboradorRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public Task<bool> Handle(AlterarNomeDoColaboradorCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                //atualizar o commando para a entidade mapeada usando Mapper

                _repositorio.Atualize(new Colaborador(request.Id, request.Nome, request.DataDeNascimento, request.GanhaSalario));

                //lançar algum evento, enviar mensagem para a fila, etc.

                return Task.FromResult(true);
            }

            // lança notificação

            return Task.FromResult(false);
        }
    }
}