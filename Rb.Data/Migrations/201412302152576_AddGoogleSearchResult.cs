namespace Rb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGoogleSearchResult : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GoogleSearchResult",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        BookInternalId = c.Int(nullable: false),
                        QueryString = c.String(),
                        RequestType = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                        TotalResults = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Book", t => new { t.BookId, t.BookInternalId }, cascadeDelete: true)
                .Index(t => new { t.BookId, t.BookInternalId });
            
            CreateTable(
                "dbo.GoogleSearchResultItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Snippet = c.String(),
                        Title = c.String(),
                        Url = c.String(),
                        SearchResult_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GoogleSearchResult", t => t.SearchResult_Id)
                .Index(t => t.SearchResult_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GoogleSearchResultItem", "SearchResult_Id", "dbo.GoogleSearchResult");
            DropForeignKey("dbo.GoogleSearchResult", new[] { "BookId", "BookInternalId" }, "dbo.Book");
            DropIndex("dbo.GoogleSearchResultItem", new[] { "SearchResult_Id" });
            DropIndex("dbo.GoogleSearchResult", new[] { "BookId", "BookInternalId" });
            DropTable("dbo.GoogleSearchResultItem");
            DropTable("dbo.GoogleSearchResult");
        }
    }
}
