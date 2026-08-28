using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces
{
    public interface IUserRepository : IGenericRepository<ApplicationUser>
    {
        Task<ApplicationUser?> GetByEmailAsync(string email);
    }
}
