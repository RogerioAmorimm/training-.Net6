using Microservices.DomainCore.Commands;
using System;

namespace Microservices.Domain.Commands
{
    public abstract class ColaboradorCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public bool GanhaSalario { get; set; }
    }
}