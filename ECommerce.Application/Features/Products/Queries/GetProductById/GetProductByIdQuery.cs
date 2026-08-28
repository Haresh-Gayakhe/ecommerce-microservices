using ECommerce.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Features.Products.Queries.GetProductById
{
    public record GetProductByIdQuery(
        Guid ProductId) : IRequest<ProductDto>;
}
