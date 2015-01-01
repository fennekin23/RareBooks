namespace Rb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyOnYandexSearchResult : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.YandexSearchResult", new[] { "BookId", "BookInternalId" });
            AddForeignKey("dbo.YandexSearchResult", new[] { "BookId", "BookInternalId" }, "dbo.Book", new[] { "Id", "InternalId" }, cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.YandexSearchResult", new[] { "BookId", "BookInternalId" }, "dbo.Book");
            DropIndex("dbo.YandexSearchResult", new[] { "BookId", "BookInternalId" });
        }
    }
}
