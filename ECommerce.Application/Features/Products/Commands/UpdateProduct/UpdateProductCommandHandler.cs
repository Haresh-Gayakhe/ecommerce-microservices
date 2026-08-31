using ECommerce.Application.Exceptions;
using ECommerce.Application.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;

        public UpdateProductCommandHandler(IProductRepository repository, IUnitOfWork unitOfWork, ICacheService cacheService)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.ProductId);

            if(product is null)
            {
                throw new NotFoundException("Product not found");
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.StockQuantity = request.StockQuantity;
            product.CategoryId = request.CategoryId;
            product.UpdatedOn = DateTime.UtcNow;

            _repository.Update(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _cacheService.RemoveAsync($"product:{product.Id}");

            return Unit.Value;
        }
    }
}
