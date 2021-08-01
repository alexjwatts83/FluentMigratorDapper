using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FluentMigratorDapper.Application.Interfaces;
using FluentMigratorDapper.Domain.Entities;
using Microsoft.Extensions.Options;

namespace FluentMigratorDapper.Infrastructure.Persistence.Repositories
{
    public class GenericCrudRepository<TEntity, TKey> : IGenericCrudRepository<TEntity, TKey>
        where TEntity : BaseEntity
    {
        private readonly string _connectionString;

        public string GetByIdAsyncSql => _scripts.GetByIdAsyncSql;
        public string GetAllAsyncSql => _scripts.GetAllAsyncSql;
        public string AddAsyncSql => _scripts.AddAsyncSql;
        public string UpdateAsyncSql => _scripts.UpdateAsyncSql;
        public string DeleteAsyncSql => _scripts.DeleteAsyncSql;

        private IGenericCrudRepositoryScripts _scripts;

        public GenericCrudRepository(IOptions<ConnectionStringSettings> connectionStrings, IGenericCrudRepositoryScripts scripts)
        {
            _connectionString = connectionStrings.Value.Database;
            _scripts = scripts;
        }

        protected async Task<TEntity> QuerySingleOrDefaultAsync(string sql, TKey id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            return await connection.QuerySingleOrDefaultAsync<TEntity>(sql, new { Id = id });
        }

        protected async Task<IReadOnlyList<TEntity>> QueryAsync(string sql)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var result = await connection.QueryAsync<TEntity>(sql);
            // TODO: double check the reasoning to use a IReadOnlyList compared to IEnumerable
            return result.ToList().AsReadOnly();
        }

        public async Task<int> ExecuteAsync(string sql, object param)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            return await connection.ExecuteAsync(sql, param);
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await QuerySingleOrDefaultAsync(GetByIdAsyncSql, id);
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return await QueryAsync(GetAllAsyncSql);
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            return await ExecuteAsync(AddAsyncSql, entity);
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            return await ExecuteAsync(UpdateAsyncSql, entity);
        }

        public async Task<int> DeleteAsync(TKey id)
        {
            return await ExecuteAsync(DeleteAsyncSql, new { Id = id });
        }
    }
}
