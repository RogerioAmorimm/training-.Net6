using FluentValidation;

namespace Microservices.Validators.Base
{
    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        public abstract void SingRules();
    }
}
