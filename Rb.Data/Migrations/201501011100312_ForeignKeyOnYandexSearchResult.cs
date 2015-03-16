using System.Data.Entity.Migrations;

namespace Rb.Data.Migrations
{
    public partial class ForeignKeyOnYandexSearchResult : DbMigration
    {
        public override void Down()
        {
            DropForeignKey("dbo.YandexSearchResult", new[] { "BookId", "BookInternalId" }, "dbo.Book");
            DropIndex("dbo.YandexSearchResult", new[] { "BookId", "BookInternalId" });
        }

        public override void Up()
        {
            CreateIndex("dbo.YandexSearchResult", new[] { "BookId", "BookInternalId" });
            AddForeignKey("dbo.YandexSearchResult", new[] { "BookId", "BookInternalId" }, "dbo.Book", new[] { "Id", "InternalId" }, true);
        }
    }
}