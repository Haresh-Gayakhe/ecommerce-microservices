using MediatR;

namespace ECommerce.Application.Features.Identity.Commands.RegisterUser
{
    public record RegisterUserCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password) : IRequest<Guid>;
}
