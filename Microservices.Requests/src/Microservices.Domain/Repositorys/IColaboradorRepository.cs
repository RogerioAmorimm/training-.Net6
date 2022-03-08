using Microservices.Domain.AggregatesModel;

namespace Microservices.Domain.Repositorys
{
    public interface IColaboradorRepository
    {
        void Atualize(Colaborador colaborador);
    }
}