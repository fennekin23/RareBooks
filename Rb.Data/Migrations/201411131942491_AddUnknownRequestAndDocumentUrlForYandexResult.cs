using System.Data.Entity.Migrations;

namespace Rb.Data.Migrations
{
    public partial class AddUnknownRequestAndDocumentUrlForYandexResult : DbMigration
    {
        public override void Down()
        {
            DropColumn("dbo.YandexSearchResult", "DocumentUrl");
        }

        public override void Up()
        {
            AddColumn("dbo.YandexSearchResult", "DocumentUrl", c => c.String());
        }
    }
}