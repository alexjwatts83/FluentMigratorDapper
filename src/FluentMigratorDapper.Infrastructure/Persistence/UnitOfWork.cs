using System;
using System.Collections;
using FluentMigratorDapper.Application.Interfaces;
using FluentMigratorDapper.Domain.Entities;
using FluentMigratorDapper.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Options;

namespace FluentMigratorDapper.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IOptions<ConnectionStringSettings> _connectionStrings;
        private Hashtable _repositories;

        public UnitOfWork(IOptions<ConnectionStringSettings> connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        public IGenericCrudRepository<TEntity, TKey> Repository<TEntity, TKey>(IGenericCrudRepositoryScripts scripts)
            where TEntity : BaseEntity
        {
            if (_repositories == null) _repositories = new Hashtable();

            var repoKey = $"{typeof(TEntity).Name}-{typeof(TKey).Name}";

            if (!_repositories.ContainsKey(repoKey))
            {
                var repositoryType = typeof(GenericCrudRepository<,>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity), typeof(TKey)), _connectionStrings, scripts);

                _repositories.Add(repoKey, repositoryInstance);
            }

            return (IGenericCrudRepository<TEntity, TKey>)_repositories[repoKey];
        }
    }
}
