using System.Data.Entity.Migrations;

namespace Rb.Data.Migrations
{
    public partial class ExtendBookToGoogle : DbMigration
    {
        public override void Down()
        {
            DropColumn("dbo.Book", "ProcessedByGoogle");
        }

        public override void Up()
        {
            AddColumn("dbo.Book", "ProcessedByGoogle", c => c.Boolean(false));
        }
    }
}