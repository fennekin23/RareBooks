using System.Data.Entity.Migrations;

namespace Rb.Data.Migrations
{
    public partial class AddRequests : DbMigration
    {
        public override void Down()
        {
            DropTable("dbo.Request");
        }

        public override void Up()
        {
            CreateTable(
                "dbo.Request",
                c => new
                {
                    Id = c.Int(false, true),
                    Description = c.String(),
                    Type = c.Int(false),
                })
                .PrimaryKey(t => t.Id);
        }
    }
}