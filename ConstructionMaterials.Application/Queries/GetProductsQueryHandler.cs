using AutoMapper;
using ConstructionMaterials.Application.Contracts;
using ConstructionMaterials.Application.Models;
using MediatR;


namespace ConstructionMaterials.Application.Queries;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PagedResult<ProductDto>>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResult<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        // Fetch paginated products from the repository
        var pagedProducts = await _repository.GetPagedProductsAsync(request.PaginationParameters);

        // Map the domain products to DTOs
        var pagedProductDtos = _mapper.Map<PagedResult<ProductDto>>(pagedProducts);

        return pagedProductDtos;
    }
}