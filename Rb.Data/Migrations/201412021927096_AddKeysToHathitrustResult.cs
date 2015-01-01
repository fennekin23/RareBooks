using System.Data.Entity.Migrations;

namespace Rb.Data.Migrations
{
    public partial class AddKeysToHathitrustResult : DbMigration
    {
        public override void Down()
        {
            DropColumn("dbo.HathitrustResult", "BookId");
        }

        public override void Up()
        {
            AddColumn("dbo.HathitrustResult", "BookId", c => c.Int(false));
        }
    }
}