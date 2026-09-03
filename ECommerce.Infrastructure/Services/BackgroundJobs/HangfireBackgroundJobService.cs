using ECommerce.Application.Interfaces;
using Hangfire;

namespace ECommerce.Infrastructure.Services.BackgroundJobs
{
    public class HangfireBackgroundJobService : IBackgroundJobService
    {
        public void EnqueueWelcomeEmail(string email, string firstName)
        {
            BackgroundJob.Enqueue<IEmailService>(
                service => service.SendWelcomeEmailAsync(email, firstName));
        }
    }
}
