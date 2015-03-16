using System.Data.Entity.Migrations;

namespace Rb.Data.Migrations
{
    public partial class AddBookIdToYandexSearchResult : DbMigration
    {
        public override void Down()
        {
            DropColumn("dbo.YandexSearchResult", "BookId");
        }

        public override void Up()
        {
            AddColumn("dbo.YandexSearchResult", "BookId", c => c.Int(false));
        }
    }
}