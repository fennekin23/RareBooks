namespace Rb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HathitrustResultForeignKey : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.HathitrustResult", new[] { "BookId", "BookInternalId" });
            AddForeignKey("dbo.HathitrustResult", new[] { "BookId", "BookInternalId" }, "dbo.Book", new[] { "Id", "InternalId" }, cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HathitrustResult", new[] { "BookId", "BookInternalId" }, "dbo.Book");
            DropIndex("dbo.HathitrustResult", new[] { "BookId", "BookInternalId" });
        }
    }
}
