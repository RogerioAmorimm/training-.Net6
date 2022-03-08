using Microservices.Application.Dtos;
using System;

namespace Microservices.Application.Services.Colaborador.Interfaces
{
    public interface IColaboradorQuerysServices
    {
        ColaboradorDto Obter(Guid Id);
    }
}