using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task AddAsync(Category category);
    }
}
