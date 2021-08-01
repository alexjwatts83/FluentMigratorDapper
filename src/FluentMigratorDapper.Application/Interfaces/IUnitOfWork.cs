using FluentMigratorDapper.Domain.Entities;

namespace FluentMigratorDapper.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericCrudRepository<TEntity, TKey> Repository<TEntity, TKey>(IGenericCrudRepositoryScripts scripts)
            where TEntity : BaseEntity;
    }
}
