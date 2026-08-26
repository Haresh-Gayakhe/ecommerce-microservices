using MediatR;

namespace ECommerce.Application.Features.Identity.Commands.LoginUser
{
    public record LoginUserCommand(
        string Email,
        string Password) 
        : IRequest<string>;
}
