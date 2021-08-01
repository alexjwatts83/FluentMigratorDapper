using System.Collections.Generic;
using System.Threading.Tasks;
using FluentMigratorDapper.Domain.Entities;

namespace FluentMigratorDapper.Application.Interfaces
{
    public interface IGenericCrudRepository<TEntity, TKey> where TEntity : BaseEntity
    {
        //IGenericCrudRepositoryScripts Scripts { get; }
        Task<TEntity> GetByIdAsync(TKey id);
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<int> AddAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> DeleteAsync(TKey id);
    }
}
