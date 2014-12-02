namespace Rb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKeysToHathitrustResult : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HathitrustResult", "BookId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HathitrustResult", "BookId");
        }
    }
}
