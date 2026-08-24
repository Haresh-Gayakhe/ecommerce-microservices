using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Products.Queries.GetAllProducts
{
    public record GetAllProductsQuery() : IRequest<IEnumerable<ProductDto>>;
}
