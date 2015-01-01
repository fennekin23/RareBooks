using System.Data.Entity.Migrations;

namespace Rb.Data.Migrations
{
    public partial class WorldcatForeignKey : DbMigration
    {
        public override void Down()
        {
            DropForeignKey("dbo.WorldcatResult", new[] { "BookId", "BookInternalId" }, "dbo.Book");
            DropIndex("dbo.WorldcatResult", new[] { "BookId", "BookInternalId" });
        }

        public override void Up()
        {
            CreateIndex("dbo.WorldcatResult", new[] { "BookId", "BookInternalId" });
            AddForeignKey("dbo.WorldcatResult", new[] { "BookId", "BookInternalId" }, "dbo.Book", new[] { "Id", "InternalId" }, true);
        }
    }
}