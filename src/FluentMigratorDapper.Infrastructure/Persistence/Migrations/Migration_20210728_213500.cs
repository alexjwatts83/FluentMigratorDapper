using System.Linq;
using FluentMigrator;

namespace FluentMigratorDapper.Infrastructure.Persistence.Migrations
{
    //[Tags("Development")]
    [Migration(20210728_213500)]
    public class AddMovies : Migration
    {
        private void CreateMoviesTable()
        {
            Create.Table("Movies")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString(255).Nullable();
        }

        private void SeedMoviesTable()
        {
            foreach (var i in Enumerable.Range(1, 10))
            {
                Insert.IntoTable("Movies")
                    .Row(new
                    {
                        Name = $"Movie {i:D2}"
                    });
            }
        }

        public override void Down()
        {
            Delete.Table("Tags");
        }

        public override void Up()
        {
            CreateMoviesTable();
            SeedMoviesTable();
        }
    }
}
