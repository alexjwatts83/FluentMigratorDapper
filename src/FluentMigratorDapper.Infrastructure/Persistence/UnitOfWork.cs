using System;
using System.Collections;
using FluentMigratorDapper.Application.Interfaces;
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
            where TEntity : class
        {
            if (_repositories == null) _repositories = new Hashtable();
            if (_keys == null) _keys = new Hashtable();
            if (_scripts == null) _scripts = new Hashtable();

            var type = typeof(TEntity).Name;
            var key = typeof(TKey).Name;
            //var keyType = typeof(TEntity).Name;

            //if (!_keys.ContainsKey(keyType))
            //{
            //    var repositoryType = typeof(GenericCrudRepository<,,>);
            //    var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _connectionStrings);

            //    _repositories.Add(type, repositoryInstance);
            //}

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericCrudRepository<,>);
                Type[] typeArgs = { typeof(TEntity), typeof(TKey) };
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeArgs), _connectionStrings, scripts);
                //var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _connectionStrings, scripts);
                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericCrudRepository<TEntity, TKey>)_repositories[type];
        }

        //public IGenericCrudRepository<TEntity, TKey> Repository<TEntity, TKey>(IGenericCrudRepositoryScripts scripts) where TEntity : class
        //{
        //    throw new NotImplementedException();
        //}
        //public UnitOfWork(ILocationsRepository locationsRepository, IMoviesRepository movies, ITagsRepository tags)
        //{
        //    Locations = locationsRepository;
        //    Movies = movies;
        //    Tags = tags;
        //}
        //public ILocationsRepository Locations { get; }
        //public IMoviesRepository Movies { get; }
        //public ITagsRepository Tags { get; }
    }
}
