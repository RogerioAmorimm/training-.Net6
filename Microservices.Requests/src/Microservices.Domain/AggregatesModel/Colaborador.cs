using System;

namespace Microservices.Domain.AggregatesModel
{
    public class Colaborador : Entidade
    {
        public Colaborador(Guid id, string nome, DateTime dataDeNascimento, bool ganhaSalario)
        {
            Id = id;
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
            GanhaSalario = ganhaSalario;
        }

        public string Nome { get; private set; }
        public DateTime DataDeNascimento { get; private set; }
        public bool GanhaSalario { get; private set; }

        public bool EMaiorDeIdade()
        {
            return (DateTime.Today.Year - DataDeNascimento.Year) >= 18;
        }

        public bool EVoluntario()
        {
            return !GanhaSalario && EMaiorDeIdade();
        }

        public bool EMenorExplorado()
        {
            return !GanhaSalario && !EMaiorDeIdade();
        }

        public bool EMenorAprendiz()
        {
            return GanhaSalario && EMaiorDeIdade();
        }
    }
}