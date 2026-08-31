using ECommerce.Application.Exceptions;
using ECommerce.Application.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;
        public DeleteProductCommandHandler(IProductRepository repository, IUnitOfWork unitOfWork, ICacheService cacheService)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.ProductId);

            if (product is null)
            {
                throw new NotFoundException("Product not found");
            }

            product.IsDeleted = true;
            product.DeletedOn = DateTime.UtcNow;

            _repository.Update(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _cacheService.RemoveAsync($"product:{product.Id}");

            return Unit.Value;
        }
    }
}
