using ECommerce.Application.Features.Identity.Commands.LoginUser;
using ECommerce.Application.Features.Identity.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("me")]
        public IActionResult Me()
        {
            return Ok(new{
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                Email = User.FindFirstValue(ClaimTypes.Email),
                Role = User.FindFirstValue(ClaimTypes.Role)
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            var userId = await _mediator.Send(command);
            return Ok(userId);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            var token = await _mediator.Send(command);
            return Ok(token);
        }
    }
}
