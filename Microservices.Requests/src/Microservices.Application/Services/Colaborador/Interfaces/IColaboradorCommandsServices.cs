using Microservices.Application.Dtos;

namespace Microservices.Application.Services.Interfaces
{
    public interface IColaboradorCommandsServices
    {
        void AtualizarNomeDoColaborador(ColaboradorDto dto);
    }
}