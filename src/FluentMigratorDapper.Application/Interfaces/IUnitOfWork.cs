using FluentMigratorDapper.Domain.Entities;

namespace FluentMigratorDapper.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericCrudRepository<TEntity> Repository<TEntity>(IGenericCrudRepositoryScripts scripts)
            where TEntity : BaseEntity;
    }
}
