using FluentMigratorDapper.Infrastructure.Persistence.Interfaces;

namespace FluentMigratorDapper.Infrastructure.Persistence.RepositoryScripts
{
    public class TagsGenericCrudRepositoryScripts : ITagsGenericCrudRepositoryScripts
    {
        public string GetByIdAsyncSql => "SELECT TOP 1 * FROM Tags WHERE id = @id";

        public string GetAllAsyncSql => "SELECT * FROM Tags";

        public string AddAsyncSql => "INSERT INTO Tags (Id,Name) VALUES (@Id,@Name);SELECT * FROM Tags WHERE Id = @Id;";

        public string UpdateAsyncSql => "UPDATE Tags SET Name = @Name WHERE Id = @Id";

        public string DeleteAsyncSql => "DELETE FROM Tags WHERE Id = @Id";
    }
}
