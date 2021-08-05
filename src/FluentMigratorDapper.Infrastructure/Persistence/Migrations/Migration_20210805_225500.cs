using System.Linq;
using FluentMigrator;

namespace FluentMigratorDapper.Infrastructure.Persistence.Migrations
{

    [Migration(20210805_225500)]
    public class AddSponsorColsToFestivals_Events : Migration, INonProductionMigration
    {
        public override void Up()
        {
            if (!Schema.Table("Festivals_Events").Column("Sponsor").Exists())
            {
                Alter.Table("Festivals_Events")
                    .AddColumn("Sponsor").AsString(255).Nullable();
            }

            if (!Schema.Table("Festivals_Events").Column("SponsorLink").Exists())
            {
                Alter.Table("Festivals_Events")
                    .AddColumn("SponsorLink").AsString(255).Nullable();
            }
        }

        public override void Down()
        {
            // do nothing
        }
    }
}
