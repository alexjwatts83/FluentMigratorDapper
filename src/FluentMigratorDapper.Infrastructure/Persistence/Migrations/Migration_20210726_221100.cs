using FluentMigrator;

namespace FluentMigratorDapper.Infrastructure.Persistence.Migrations
{
    [Migration(20210721_145000)]
    public class AddLocations : Migration, IProductionMigration
    {
        private void CreateLocationsTable()
        {
            Create.Table("Locations")
                .WithColumn("Id").AsString(3).NotNullable()
                .WithColumn("Name").AsString(255).Nullable()
                .WithColumn("State").AsString(255).Nullable()
                .WithColumn("City").AsString().Nullable();
        }

        private void SeedLocationsTable()
        {
            Insert.IntoTable("Locations")
                .Row(new
                {
                    Id = "NEW",
                    Name = "Newcastle",
                    State = "New South Wales",
                    City = "Newcastle"
                })
                .Row(new
                {
                    Id = "SYD",
                    Name = "Sydney",
                    State = "New South Wales",
                    City = "Sydney"
                })
                .Row(new
                {
                    Id = "BRI",
                    Name = "Brisbane",
                    State = "Queensland",
                    City = "Brisbane"
                });
        }

        public override void Down()
        {
            Delete.Table("Locations");
        }

        public override void Up()
        {
            CreateLocationsTable();
            SeedLocationsTable();
        }
    }
}
