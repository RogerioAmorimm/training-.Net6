using FluentValidation;
using FluentValidation.Results;
using Microservices.Dtos.UserDto;
using Microservices.Validators.Base;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.Validators.UserValidator
{
    public class LoginUserValidator : BaseValidator<LoginUserDto>
    {
        public override void SingRules()
        {
            ValidatePassword();
            ValidateEmail();
        }
        private void ValidateEmail() 
        {
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty();
        }
        private void ValidatePassword()
        {
            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty();
        }

        public override Task<ValidationResult> ValidateAsync(ValidationContext<LoginUserDto> context, CancellationToken cancellation = default)
        {
            SingRules();
            return base.ValidateAsync(context, cancellation);
        }
    }
}
