using System.Data.Entity.Migrations;

namespace Rb.Data.Migrations
{
    public partial class AddYandexSearchResult : DbMigration
    {
        public override void Down()
        {
            DropTable("dbo.YandexSearchResult");
        }

        public override void Up()
        {
            CreateTable(
                "dbo.YandexSearchResult",
                c => new
                {
                    Id = c.Int(false, true),
                    BookId = c.Int(false),
                    DocumentDomain = c.String(),
                    DocumentLanguage = c.String(),
                    DocumentPassages = c.String(),
                    DocumentSize = c.Int(false),
                    DocumentTitle = c.String(),
                    FoundDocuments = c.Int(false),
                    QueryString = c.String(),
                    RequestType = c.Int(false),
                    TimeStamp = c.DateTime(false),
                })
                .PrimaryKey(t => t.Id);
        }
    }
}