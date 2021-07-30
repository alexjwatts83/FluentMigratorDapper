using FluentMigratorDapper.Application.Interfaces;
using FluentMigratorDapper.Domain.Entities;
using Microsoft.Extensions.Options;

namespace FluentMigratorDapper.Infrastructure.Persistence.Repositories
{

    public class MoviesRepository : BaseRepository<Movies, int>, IMoviesRepository
    {
        public MoviesRepository(IOptions<ConnectionStringSettings> connectionStrings) : base(connectionStrings)
        {
        }

        public override string GetByIdAsyncSql => "SELECT TOP 1 * FROM [Movies] WHERE id = @id";

        public override string GetAllAsyncSql => "SELECT * FROM [Movies]";

        public override string AddAsyncSql => "INSERT INTO [Movies] (Name) VALUES (@Name)";

        public override string UpdateAsyncSql => "UPDATE [Movies] SET Name = @Name WHERE Id = @Id";

        public override string DeleteAsyncSql => "DELETE FROM [Movies] WHERE Id = @Id";
    }
}
