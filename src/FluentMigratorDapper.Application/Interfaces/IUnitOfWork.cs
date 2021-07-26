using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentMigratorDapper.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>();
        Task<int> Complete();
    }
}
