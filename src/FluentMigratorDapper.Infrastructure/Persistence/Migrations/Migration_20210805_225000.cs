using System.Linq;
using FluentMigrator;

namespace FluentMigratorDapper.Infrastructure.Persistence.Migrations
{

    [Migration(20210805_225000)]
    public class AddFestivalEventsTables : Migration, INonProductionMigration
    {
        public override void Up()
        {
            var sql = @"
CREATE TABLE [dbo].[Festivals_Events](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FestivalID] [nvarchar](3) NULL,
	[ReferenceID] [nvarchar](255) NULL,
	[LocationID] [nvarchar](3) NULL,
	[Type] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
	[ShortDescription] [nvarchar](max) NULL,
	[LongDescription] [nvarchar](max) NULL,
	[Thumbnail] [nvarchar](255) NULL,
	[Link] [nvarchar](255) NULL,
	[Date] [datetime] NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_Festivals_Events] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO";
            Execute.Sql(sql);
        }

        public override void Down()
        {
            Delete.Table("Festivals_Events");
        }
    }
}
