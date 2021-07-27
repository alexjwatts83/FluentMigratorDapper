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
    public class LocationsRepository : ILocationsRepository
    {
        private readonly string _connectionString;

        public LocationsRepository(IOptions<ConnectionStringSettings> connectionStrings)
        {
            _connectionString = connectionStrings.Value.Database;
        }

        public async Task<Location> GetByIdAsync(string id)
        {
            const string sql = "SELECT TOP 1 * FROM Locations WHERE id = @id";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            return await connection.QuerySingleOrDefaultAsync<Location>(sql, new { Id = id });
        }

        public async Task<IReadOnlyList<Location>> GetAllAsync()
        {
            const string sql = "SELECT * FROM Locations";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var result = await connection.QueryAsync<Location>(sql);
            // TODO: double check the reasoning to use a IReadOnlyList compared to IEnumerable
            return result.ToList().AsReadOnly();
        }

        public async Task<int> AddAsync(Location entity)
        {
            const string sql = "INSERT INTO Locations (Id,Name,State,City) values (@Id,@Name,@State,@City)";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            return await connection.ExecuteAsync(sql, entity);
        }

        public async Task<int> UpdateAsync(Location entity)
        {
            const string sql = "UPDATE Locations SET Id = @Id, Name = @Name, State = @State, City = @City)";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            return await connection.ExecuteAsync(sql, entity);
        }

        public async Task<int> DeleteAsync(string id)
        {
            const string sql = "DELETE FROM Locations WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            return await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
