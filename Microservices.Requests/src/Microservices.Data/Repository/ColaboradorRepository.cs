using Microservices.Data.Contexts;
using Microservices.Domain.AggregatesModel;
using Microservices.Domain.Repositorys;
using System;

namespace Microservices.Data.Repositorios
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly ITemplateContext _contexto;

        public ColaboradorRepository(ITemplateContext contexto)
        {
            _contexto = contexto;
        }

        public void Atualize(Colaborador colaborador)
        {
            throw new NotImplementedException();
        }
    }
}