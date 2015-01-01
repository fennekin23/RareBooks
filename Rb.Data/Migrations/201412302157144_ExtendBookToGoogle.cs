namespace Rb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendBookToGoogle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "ProcessedByGoogle", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "ProcessedByGoogle");
        }
    }
}
