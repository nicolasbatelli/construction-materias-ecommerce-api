using ConstructionMaterials.Application.Models;
using ConstructionMaterials.Infrastructure.Repositories;
using ConstructionMaterials.Infrastructure.UnitOfWork;
using MediatR;

namespace ConstructionMaterials.Application.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IProductRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IProductRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(request.Name, request.Price);

        await _repository.AddAsync(product);
        await _unitOfWork.SaveChangesAsync();

        return new ProductDto { Id = product.Id, Name = product.Name, Price = product.Price };
    }
}