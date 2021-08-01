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
        private Hashtable _keys;
        private Hashtable _scripts;

        public UnitOfWork(IOptions<ConnectionStringSettings> connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        public IGenericCrudRepository<TEntity> Repository<TEntity>(IGenericCrudRepositoryScripts scripts)
            where TEntity : BaseEntity
        {
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericCrudRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _connectionStrings, scripts);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericCrudRepository<TEntity>)_repositories[type];
        }
    }
}
