using System.Linq;
using FluentMigrator;

namespace FluentMigratorDapper.Infrastructure.Persistence.Migrations
{
    [Migration(20210728_213000)]
    public class AddTags : NonProductionMigration
    {
        private void CreateTagsTable()
        {
            Create.Table("Tags")
                .WithColumn("Id").AsString(3).NotNullable()
                .WithColumn("Name").AsString(255).Nullable();
        }

        private void SeedTagsTable()
        {
            foreach(var i in Enumerable.Range(1, 10))
            {
                Insert.IntoTable("Locations")
                    .Row(new
                    {
                        Id = $"t{i:D2}",
                        Name = $"Tag {i:D2}"
                    });
            }
        }

        public override void Down()
        {
            Delete.Table("Tags");
        }

        public override void Up()
        {
            CreateTagsTable();
            SeedTagsTable();
        }
    }
}
