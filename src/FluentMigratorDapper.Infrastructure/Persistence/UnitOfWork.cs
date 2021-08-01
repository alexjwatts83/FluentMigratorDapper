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

        public IGenericCrudRepository<TEntity, TKey> Repository<TEntity, TKey>(IGenericCrudRepositoryScripts scripts)
            where TEntity : BaseEntity
        {
            if (_repositories == null) _repositories = new Hashtable();
            if (_keys == null) _keys = new Hashtable();
            if (_scripts == null) _scripts = new Hashtable();

            var type = typeof(TEntity).Name;
            var key = typeof(TKey).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericCrudRepository<,>);
                Type[] typeArgs = { typeof(TEntity), typeof(TKey) };
                var makeMe = repositoryType.MakeGenericType(typeArgs);
                var objParams = new object[] { _connectionStrings.Value.Database, scripts };
                var repositoryInstance = Activator.CreateInstance(makeMe, objParams);
                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericCrudRepository<TEntity, TKey>)_repositories[type];
        }
    }
}
