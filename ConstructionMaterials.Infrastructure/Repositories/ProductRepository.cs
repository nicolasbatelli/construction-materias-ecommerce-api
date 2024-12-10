using ConstructionMaterials.Application.Contracts;
using ConstructionMaterials.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace ConstructionMaterials.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public async Task<PagedResult<Product>> GetPagedProductsAsync(PaginationParameters paginationParameters)
    {
        var query = _context.Products.AsQueryable();
        var totalItems = await query.CountAsync();
        var items = await query.Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize) //Review condition operation
                                .Take(paginationParameters.PageSize)
                                .Select(p => new Product(p.Name, p.Price, p.Id))
                                .ToListAsync();

        return new PagedResult<Product>(items, totalItems, paginationParameters.PageNumber, paginationParameters.PageSize);
    }
}
