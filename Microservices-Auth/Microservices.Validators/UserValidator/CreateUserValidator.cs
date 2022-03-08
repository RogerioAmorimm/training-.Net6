using FluentValidation;
using FluentValidation.Results;
using Microservices.Dtos.UserDto;
using Microservices.Dtos.UserDto.Enum;
using Microservices.Repositories.UserRepository;
using Microservices.Validators.Base;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.Validators.UserValidator
{
    public class CreateUserValidator : BaseValidator<CreateUserDto>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public override void SingRules()
        {
            ValidatePassword();
            ValidateEmail();
            ValidateRole();
        }
        private void ValidatePassword()
        {
            RuleFor(x => x.RePassword)
                .NotEmpty();
            RuleFor(x => x.Password)
                .NotEmpty()
                .Equal(x => x.RePassword)
                .WithMessage("Passwords must be the same")
                .MinimumLength(6)
                .WithMessage("Password must contain at least 6 characters")
                .Must(pass=>ValidateStrongPassword(pass))
                .WithMessage("the password must have an uppercase and a special character");

        }
        private bool ValidateStrongPassword(string password) 
        {
            if (Regex.IsMatch(password, "(?=.*[@#$%^&+=])")
               && password.Any(x => char.IsDigit(x))
               && password.Any(x => char.IsUpper(x))) return true;
            return false;
        }
        private void ValidateEmail() 
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .Must((_, email) => ValidateEmail(email))
                .WithMessage("email is already in use, try another");
        }
        private bool ValidateEmail(string email)
            =>  _userRepository.GetUserByEmail(email) == null;
        private void ValidateRole() 
        {
            RuleFor(x => x.Role)
                .NotNull()
                .NotEmpty()
                .Must((_, x)=> IsValidRole(x))
                .WithMessage("select a valid role");
        }
        private bool IsValidRole(Roles role) 
            => Enum.IsDefined(typeof(Roles), role);
            
        public override Task<ValidationResult> ValidateAsync(ValidationContext<CreateUserDto> context, CancellationToken cancellation = default)
        {
            SingRules();
            return base.ValidateAsync(context, cancellation);
        }
    }
}
