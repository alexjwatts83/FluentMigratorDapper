using FluentMigratorDapper.Application.Interfaces;
using FluentMigratorDapper.Domain.Entities;
using Microsoft.Extensions.Options;

namespace FluentMigratorDapper.Infrastructure.Persistence.Repositories
{
    public class LocationsRepository : BaseRepository<Location, string>, ILocationsRepository
    {
        public LocationsRepository(IOptions<ConnectionStringSettings> connectionStrings) : base(connectionStrings)
        {
        }

        public override string GetByIdAsyncSql => "SELECT TOP 1 * FROM Locations WHERE id = @id";

        public override string GetAllAsyncSql => "SELECT * FROM Locations";

        public override string AddAsyncSql => "INSERT INTO Locations (Id,Name,State,City) values (@Id,@Name,@State,@City)";

        public override string UpdateAsyncSql => "UPDATE Locations SET Id = @Id, Name = @Name, State = @State, City = @City";

        public override string DeleteAsyncSql => "DELETE FROM Locations WHERE Id = @Id";
    }
}
