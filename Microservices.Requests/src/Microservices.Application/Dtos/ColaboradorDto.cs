using System;

namespace Microservices.Application.Dtos
{
    public class ColaboradorDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public bool GanhaSalario { get; set; }
    }
}