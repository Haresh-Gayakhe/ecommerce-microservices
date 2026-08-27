using ECommerce.Application.Common.Models;
using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Products.Queries.SearchProducts
{
    public record SearchProductsQuery(ProductQueryParameters Parameters) : IRequest<IEnumerable<ProductDto>>;
}
