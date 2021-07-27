using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentMigratorDapper.Application.Interfaces
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(TKey id);
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<int> AddAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> DeleteAsync(TKey id);
    }
}
