using FluentValidation;

namespace ECommerce.Application.Features.Identity.Commands.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            //RuleFor(x => x.Email).NotEmpty().EmailAddress();
            //RuleFor(x => x.Password).MinimumLength(8);
        }
    }
}
