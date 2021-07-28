using System.Linq;
using FluentMigrator;

namespace FluentMigratorDapper.Infrastructure.Persistence.Migrations
{
    [Tags("Development", "QA", "UAT")]
    public class NonProductionMigration : Migration
    {
        public override void Down()
        {
            //throw new NotImplementedException();
        }

        public override void Up()
        {
            //throw new NotImplementedException();
        }
    }
}
