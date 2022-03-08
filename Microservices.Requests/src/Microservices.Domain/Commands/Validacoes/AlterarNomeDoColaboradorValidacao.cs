namespace Microservices.Domain.Commands.Validacoes
{
    internal class AlterarNomeDoColaboradorValidacao : ColaboradorValidacao<AlterarNomeDoColaboradorCommand>
    {
        public override void AssinarRegras()
        {
            ValidarNome();
        }
    }
}