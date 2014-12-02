namespace Rb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorldcatForeignKey : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.WorldcatResult", new[] { "BookId", "BookInternalId" });
            AddForeignKey("dbo.WorldcatResult", new[] { "BookId", "BookInternalId" }, "dbo.Book", new[] { "Id", "InternalId" }, cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorldcatResult", new[] { "BookId", "BookInternalId" }, "dbo.Book");
            DropIndex("dbo.WorldcatResult", new[] { "BookId", "BookInternalId" });
        }
    }
}
