namespace Rb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rename : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.HathitrustResult", "BookId", "BookInternalId");
            RenameColumn("dbo.WorldcatResult", "BookId", "BookInternalId");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.WorldcatResult", "BookInternalId", "BookId");
            RenameColumn("dbo.HathitrustResult", "BookInternalId", "BookId");
        }
    }
}
