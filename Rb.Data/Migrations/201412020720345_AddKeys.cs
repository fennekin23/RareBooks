namespace Rb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKeys : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Book");
            AddColumn("dbo.WorldcatResult", "BookId", c => c.Int(nullable: false));
            AlterColumn("dbo.Book", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Book", new[] { "Id", "InternalId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Book");
            AlterColumn("dbo.Book", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.WorldcatResult", "BookId");
            AddPrimaryKey("dbo.Book", "Id");
        }
    }
}
