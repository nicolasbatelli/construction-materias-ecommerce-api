using ConstructionMaterials.Application.Models;
using ConstructionMaterials.Domain.Common;
using MediatR;

namespace ConstructionMaterials.Application.Queries;

public class GetProductsQuery : IRequest<PagedResult<ProductDto>>
{
    public PaginationParameters PaginationParameters { get; set; }    
}
