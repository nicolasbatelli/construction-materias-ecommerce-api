using ConstructionMaterials.Domain.Common;

namespace ConstructionMaterials.Infrastructure.Repositories;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task<PagedResult<Product>> GetPagedProductsAsync(PaginationParameters paginationParameters);
}
