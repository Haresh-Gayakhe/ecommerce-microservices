using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Categories.Queries.GetAllCategories
{
    public record GetAllCategoriesQuery() : IRequest<IEnumerable<CategoryDto>>;
}
