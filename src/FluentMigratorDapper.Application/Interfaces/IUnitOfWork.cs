using System;
using System.Threading.Tasks;

namespace FluentMigratorDapper.Application.Interfaces
{
    public interface IUnitOfWork
    {
        //IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : class;
        ILocationsRepository Locations { get; }
        //Task<int> Complete();
    }
}
