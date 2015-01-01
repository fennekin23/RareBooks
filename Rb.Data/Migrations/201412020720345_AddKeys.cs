using System.Data.Entity.Migrations;

namespace Rb.Data.Migrations
{
    public partial class AddKeys : DbMigration
    {
        public override void Down()
        {
            DropPrimaryKey("dbo.Book");
            AlterColumn("dbo.Book", "Id", c => c.Int(false, true));
            DropColumn("dbo.WorldcatResult", "BookId");
            AddPrimaryKey("dbo.Book", "Id");
        }

        public override void Up()
        {
            DropPrimaryKey("dbo.Book");
            AddColumn("dbo.WorldcatResult", "BookId", c => c.Int(false));
            AlterColumn("dbo.Book", "Id", c => c.Int(false));
            AddPrimaryKey("dbo.Book", new[] { "Id", "InternalId" });
        }
    }
}