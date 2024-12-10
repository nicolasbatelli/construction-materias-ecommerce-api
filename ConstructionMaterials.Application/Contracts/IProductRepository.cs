
using ConstructionMaterials.Application.Models;

namespace ConstructionMaterials.Application.Contracts;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task<PagedResult<Product>> GetPagedProductsAsync(PaginationParameters paginationParameters);
}
