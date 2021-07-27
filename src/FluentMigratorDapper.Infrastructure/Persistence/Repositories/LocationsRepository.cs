using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using FluentMigratorDapper.Application.Interfaces;
using FluentMigratorDapper.Domain.Entities;
using Microsoft.Extensions.Options;

namespace FluentMigratorDapper.Infrastructure.Persistence.Repositories
{
    public class LocationsRepository : ILocationsRepository
    {
        private readonly string _connectionString;

        private IDbConnection _connection => new SqlConnection(_connectionString);

        public LocationsRepository(IOptions<ConnectionStringSettings> connectionStrings)
        {
            _connectionString = connectionStrings.Value.Database;
        }

        public Task<Location> GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<Location>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> AddAsync(Location entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> UpdateAsync(Location entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> DeleteAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
