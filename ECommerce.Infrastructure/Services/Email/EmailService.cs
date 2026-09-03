using ECommerce.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace ECommerce.Infrastructure.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly ILogger _logger;
        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }

        public async Task SendWelcomeEmailAsync(string email, string firstName)
        {
            await Task.Delay(3000);

            _logger.LogInformation("Welcome email sent to {Email}", email);
        }
    }
}
