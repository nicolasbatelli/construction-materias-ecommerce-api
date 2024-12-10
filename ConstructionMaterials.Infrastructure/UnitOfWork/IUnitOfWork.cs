namespace ConstructionMaterials.Infrastructure.UnitOfWork;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
