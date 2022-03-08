using Microservices.Application.Dtos;
using Microservices.Application.Services.Colaborador.Interfaces;
using Microservices.Domain.Repositorys;
using MediatR;
using System;

namespace Microservices.Application.Services
{
    public class ColaboradorServices : IColaboradorQuerysServices
    {
        private readonly IMediator _mediator;
        private readonly IColaboradorRepository _repositorio;

        public ColaboradorServices(IMediator mediator, IColaboradorRepository repositorio)
        {
            _mediator = mediator;
            _repositorio = repositorio;
        }

        public ColaboradorDto Obter(Guid id)
        {
            // Querys retornam dados, usar dapper preferencialmente para consultas.
            //_repositorio.Obter(id);

            return new ColaboradorDto();
        }
    }
}