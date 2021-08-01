using FluentMigratorDapper.Infrastructure.Persistence.Interfaces;

namespace FluentMigratorDapper.Infrastructure.Persistence.RepositoryScripts
{
    public class MoviesGenericCrudRepositoryScripts : IMoviesGenericCrudRepositoryScripts
    {
        public string GetByIdAsyncSql => "SELECT TOP 1 * FROM [Movies] WHERE id = @id";

        public string GetAllAsyncSql => "SELECT * FROM [Movies]";

        public string AddAsyncSql => "INSERT INTO [Movies] (Name) VALUES (@Name);SELECT * FROM Movies WHERE Id = CAST(SCOPE_IDENTITY() AS INT);";

        public string UpdateAsyncSql => "UPDATE [Movies] SET Name = @Name WHERE Id = @Id";

        public string DeleteAsyncSql => "DELETE FROM [Movies] WHERE Id = @Id";
    }
}
