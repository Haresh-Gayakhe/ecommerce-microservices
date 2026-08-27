using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Products.Queries.SearchProducts
{
    public class SearchProductsQueryHandler : IRequestHandler<SearchProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public SearchProductsQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetProductsAsync(request.Parameters);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
    }
}
