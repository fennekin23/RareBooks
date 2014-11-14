namespace Rb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddYandexSearchResult : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.YandexSearchResult",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        DocumentDomain = c.String(),
                        DocumentLanguage = c.String(),
                        DocumentPassages = c.String(),
                        DocumentSize = c.Int(nullable: false),
                        DocumentTitle = c.String(),
                        FoundDocuments = c.Int(nullable: false),
                        QueryString = c.String(),
                        RequestType = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.YandexSearchResult");
        }
    }
}
