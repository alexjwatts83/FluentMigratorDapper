using System.Linq;
using FluentMigrator;

namespace FluentMigratorDapper.Infrastructure.Persistence.Migrations
{
    [Migration(20210804_160500)]
    public class AddTableWithGuidId : Migration, INonProductionMigration
    {
        private void CreateQuestionsTable()
        {
            Create.Table("Questions")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("Name").AsString(255).Nullable();
        }

        private void SeedQuestionsTable()
        {
            foreach (var i in Enumerable.Range(1, 10))
            {
                Insert.IntoTable("Questions")
                    .Row(new
                    {
                        Id = System.Guid.NewGuid(),
                        Name = $"Questions-{i:D2}"
                    });
            }
        }

        public override void Down()
        {
            Delete.Table("Questions");
        }

        public override void Up()
        {
            CreateQuestionsTable();
            SeedQuestionsTable();
        }
    }
}
