using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Exceptions;
using ECommerce.Application.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;
        public GetProductByIdQueryHandler(IProductRepository repository, IMapper mapper, ICacheService cacheService)
        {
            _repository = repository;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"product:{request.ProductId}";

            var cachedProduct = await _cacheService.GetAsync<ProductDto>(cacheKey);

            if(cachedProduct is not null)
            {
                return cachedProduct;
            }

            var product = await _repository.GetByIdAsync(request.ProductId);

            if(product is null)
            {
                throw new NotFoundException("Product not found.");
            }

            var dto = _mapper.Map<ProductDto>(product);

            await _cacheService.SetAsync(cacheKey, dto, TimeSpan.FromMinutes(5));

            return dto;


        }
    }
}
