using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentMigratorDapper.Application.Interfaces
{
    public interface IGenericService<TEntity, TKey>
    {
        Task<TEntity> GetByIdAsync(TKey id);
        Task<IReadOnlyList<TEntity>> ListAllAsync();
    }
}
