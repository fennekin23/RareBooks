using System.Data.Entity.Migrations;

namespace Rb.Data.Migrations
{
    public partial class ChangeFoundDocumentsToLong : DbMigration
    {
        public override void Down()
        {
            AlterColumn("dbo.YandexSearchResult", "FoundDocuments", c => c.Int(false));
        }

        public override void Up()
        {
            AlterColumn("dbo.YandexSearchResult", "FoundDocuments", c => c.Long(false));
        }
    }
}