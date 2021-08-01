using FluentMigratorDapper.Infrastructure.Persistence.Interfaces;

namespace FluentMigratorDapper.Infrastructure.Persistence.RepositoryScripts
{
    public class LocationGenericCrudRepositoryScripts : ILocationGenericCrudRepositoryScripts
    {
        public string GetByIdAsyncSql => "SELECT TOP 1 * FROM Locations WHERE id = @id";

        public string GetAllAsyncSql => "SELECT * FROM Locations";

        public string AddAsyncSql => "INSERT INTO Locations (Id,Name,State,City) VALUES (@Id,@Name,@State,@City);SELECT * FROM Locations WHERE Id = @Id;";

        public string UpdateAsyncSql => "UPDATE Locations SET Name = @Name, State = @State, City = @City WHERE Id = @Id";

        public string DeleteAsyncSql => "DELETE FROM Locations WHERE Id = @Id";
    }
}
