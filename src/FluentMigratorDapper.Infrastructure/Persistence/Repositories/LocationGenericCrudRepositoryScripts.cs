using FluentMigratorDapper.Application.Interfaces;

namespace FluentMigratorDapper.Infrastructure.Persistence.Repositories
{
    public interface ILocationGenericCrudRepositoryScripts : IGenericCrudRepositoryScripts { }
    public class LocationGenericCrudRepositoryScripts : ILocationGenericCrudRepositoryScripts
    {
        public string GetByIdAsyncSql => "SELECT TOP 1 * FROM Locations WHERE id = @id";

        public string GetAllAsyncSql => "SELECT * FROM Locations";

        public string AddAsyncSql => "INSERT INTO Locations (Id,Name,State,City) VALUES (@Id,@Name,@State,@City)";

        public string UpdateAsyncSql => "UPDATE Locations SET Name = @Name, State = @State, City = @City WHERE Id = @Id";

        public string DeleteAsyncSql => "DELETE FROM Locations WHERE Id = @Id";
    }
    //public class LocationsRepository : BaseRepository<Location, string>, ILocationsRepository
    //{
    //    public LocationsRepository(IOptions<ConnectionStringSettings> connectionStrings) : base(connectionStrings)
    //    {
    //    }

    //    public override string GetByIdAsyncSql => "SELECT TOP 1 * FROM Locations WHERE id = @id";

    //    public override string GetAllAsyncSql => "SELECT * FROM Locations";

    //    public override string AddAsyncSql => "INSERT INTO Locations (Id,Name,State,City) VALUES (@Id,@Name,@State,@City)";

    //    public override string UpdateAsyncSql => "UPDATE Locations SET Name = @Name, State = @State, City = @City WHERE Id = @Id";

    //    public override string DeleteAsyncSql => "DELETE FROM Locations WHERE Id = @Id";
    //}
}
