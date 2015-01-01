using System.Data.Entity.Migrations;

namespace Rb.Data.Migrations
{
    public partial class Rename : DbMigration
    {
        public override void Down()
        {
            RenameColumn("dbo.WorldcatResult", "BookInternalId", "BookId");
            RenameColumn("dbo.HathitrustResult", "BookInternalId", "BookId");
        }

        public override void Up()
        {
            RenameColumn("dbo.HathitrustResult", "BookId", "BookInternalId");
            RenameColumn("dbo.WorldcatResult", "BookId", "BookInternalId");
        }
    }
}