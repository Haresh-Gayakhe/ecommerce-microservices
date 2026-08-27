using ECommerce.Application.Common.Models;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(ProductQueryParameters parameters)
        {
            IQueryable<Product> query = _context.Products;

            if (!string.IsNullOrWhiteSpace(parameters.Search))
            {
                query = query.Where(x => x.Name.Contains(parameters.Search));
            }

            if (parameters.CategoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId ==  parameters.CategoryId.Value);
            }

            query = parameters.SortBy?.ToLower() switch
            {
                "price" => query.OrderBy(x => x.Price),
                _ => query.OrderBy(x => x.Name)
            };

            query = query.Skip((parameters.PageNumber - 1) * parameters.PageSize).Take(parameters.PageSize);

            return await query.ToListAsync();
        }
    }
}
