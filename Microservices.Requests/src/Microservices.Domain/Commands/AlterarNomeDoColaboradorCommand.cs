using Microservices.Domain.Commands.Validacoes;
using System;

namespace Microservices.Domain.Commands
{
    public class AlterarNomeDoColaboradorCommand : ColaboradorCommand
    {
        public AlterarNomeDoColaboradorCommand(Guid id, string nome, DateTime dataNascimento, bool ganhaSalario)
        {
            Nome = nome;
            DataDeNascimento = dataNascimento;
            GanhaSalario = ganhaSalario;
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new AlterarNomeDoColaboradorValidacao().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}