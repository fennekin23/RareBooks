using System.Data.Entity.Migrations;

namespace Rb.Data.Migrations
{
    public partial class AddGoogleSearchResult : DbMigration
    {
        public override void Down()
        {
            DropForeignKey("dbo.GoogleSearchResultItem", "SearchResult_Id", "dbo.GoogleSearchResult");
            DropForeignKey("dbo.GoogleSearchResult", new[] { "BookId", "BookInternalId" }, "dbo.Book");
            DropIndex("dbo.GoogleSearchResultItem", new[] { "SearchResult_Id" });
            DropIndex("dbo.GoogleSearchResult", new[] { "BookId", "BookInternalId" });
            DropTable("dbo.GoogleSearchResultItem");
            DropTable("dbo.GoogleSearchResult");
        }

        public override void Up()
        {
            CreateTable(
                "dbo.GoogleSearchResult",
                c => new
                {
                    Id = c.Int(false, true),
                    BookId = c.Int(false),
                    BookInternalId = c.Int(false),
                    QueryString = c.String(),
                    RequestType = c.Int(false),
                    TimeStamp = c.DateTime(false),
                    TotalResults = c.Long(false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Book", t => new { t.BookId, t.BookInternalId }, true)
                .Index(t => new { t.BookId, t.BookInternalId });

            CreateTable(
                "dbo.GoogleSearchResultItem",
                c => new
                {
                    Id = c.Int(false, true),
                    Snippet = c.String(),
                    Title = c.String(),
                    Url = c.String(),
                    SearchResult_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GoogleSearchResult", t => t.SearchResult_Id)
                .Index(t => t.SearchResult_Id);
        }
    }
}