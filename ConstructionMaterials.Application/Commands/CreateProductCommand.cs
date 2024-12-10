using ConstructionMaterials.Application.Models;
using MediatR;

namespace ConstructionMaterials.Application.Commands;

public class CreateProductCommand : IRequest<ProductDto>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
