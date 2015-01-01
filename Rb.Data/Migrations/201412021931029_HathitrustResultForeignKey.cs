using System.Data.Entity.Migrations;

namespace Rb.Data.Migrations
{
    public partial class HathitrustResultForeignKey : DbMigration
    {
        public override void Down()
        {
            DropForeignKey("dbo.HathitrustResult", new[] { "BookId", "BookInternalId" }, "dbo.Book");
            DropIndex("dbo.HathitrustResult", new[] { "BookId", "BookInternalId" });
        }

        public override void Up()
        {
            CreateIndex("dbo.HathitrustResult", new[] { "BookId", "BookInternalId" });
            AddForeignKey("dbo.HathitrustResult", new[] { "BookId", "BookInternalId" }, "dbo.Book", new[] { "Id", "InternalId" }, true);
        }
    }
}