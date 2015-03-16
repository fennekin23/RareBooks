using System.Data.Entity.Migrations;

namespace Rb.Data.Migrations
{
    public partial class RenameInYandexSearchResult : DbMigration
    {
        public override void Down()
        {
            RenameColumn("dbo.YandexSearchResult", "BookInternalId", "BookId");
        }

        public override void Up()
        {
            RenameColumn("dbo.YandexSearchResult", "BookId", "BookInternalId");
        }
    }
}