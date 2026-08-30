using MediatR;

namespace ECommerce.Application.Features.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand(
        Guid ProductId,
        string Name,
        string Description,
        decimal Price,
        int StockQuantity,
        Guid CategoryId) : IRequest<Unit>;
}
