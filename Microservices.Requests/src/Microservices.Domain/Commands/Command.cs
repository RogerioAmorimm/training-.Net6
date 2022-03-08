using FluentValidation.Results;
using MediatR;

namespace Microservices.DomainCore.Commands
{
    public abstract class Command : IRequest<bool>
    {
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}