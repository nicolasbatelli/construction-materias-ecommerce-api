namespace ConstructionMaterials.Application.Contracts;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
