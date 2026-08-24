using MediatR;

namespace ECommerce.Application.Features.Products.Commands.CreateProduct
{
    public record CreateProductCommand(
        string Name,
        string Description,
        decimal Price,
        int StockQuantity,
        Guid CategoryId
    ) : IRequest<Guid>;
    
}
