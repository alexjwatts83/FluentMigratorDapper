using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FluentMigratorDapper.Application.Interfaces;
using Microsoft.Extensions.Options;

namespace FluentMigratorDapper.Infrastructure.Persistence.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
    {
        public readonly string ConnectionString;
        public abstract string GetByIdAsyncSql { get; }
        public abstract string GetAllAsyncSql { get; }
        public abstract string AddAsyncSql { get; }
        public abstract string UpdateAsyncSql { get; }
        public abstract string DeleteAsyncSql { get; }

        protected BaseRepository(IOptions<ConnectionStringSettings> connectionStrings)
        {
            ConnectionString = connectionStrings.Value.Database;
        }

        protected async Task<TEntity> QuerySingleOrDefaultAsync(string sql, TKey id)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();

            return await connection.QuerySingleOrDefaultAsync<TEntity>(sql, new { Id = id });
        }

        protected async Task<IReadOnlyList<TEntity>> QueryAsync(string sql)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var result = await connection.QueryAsync<TEntity>(sql);
            // TODO: double check the reasoning to use a IReadOnlyList compared to IEnumerable
            return result.ToList().AsReadOnly();
        }

        public async Task<int> ExecuteAsync(string sql, object param)
        {
            using var connection = new SqlConnection(ConnectionString);
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
