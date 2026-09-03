namespace ECommerce.Application.Interfaces
{
    public interface IBackgroundJobService
    {
        void EnqueueWelcomeEmail(string email, string firstName);
    }
}
