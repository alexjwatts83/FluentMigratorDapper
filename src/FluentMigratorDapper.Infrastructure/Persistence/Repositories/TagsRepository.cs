using FluentMigratorDapper.Application.Interfaces;
using FluentMigratorDapper.Domain.Entities;
using Microsoft.Extensions.Options;

namespace FluentMigratorDapper.Infrastructure.Persistence.Repositories
{
    //public class TagsRepository : BaseRepository<Tags, string>, ITagsRepository
    //{
    //    public TagsRepository(IOptions<ConnectionStringSettings> connectionStrings) : base(connectionStrings)
    //    {
    //    }

    //    public override string GetByIdAsyncSql => "SELECT TOP 1 * FROM Tags WHERE id = @id";

    //    public override string GetAllAsyncSql => "SELECT * FROM Tags";

    //    public override string AddAsyncSql => "INSERT INTO Tags (Id,Name) VALUES (@Id,@Name)";

    //    public override string UpdateAsyncSql => "UPDATE Tags SET Name = @Name WHERE Id = @Id";

    //    public override string DeleteAsyncSql => "DELETE FROM Tags WHERE Id = @Id";
    //}
}
