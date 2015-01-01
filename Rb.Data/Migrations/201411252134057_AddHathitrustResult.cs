using System.Data.Entity.Migrations;

namespace Rb.Data.Migrations
{
    public partial class AddHathitrustResult : DbMigration
    {
        public override void Down()
        {
            DropForeignKey("dbo.HathitrustResultLink", "HathitrustResultId", "dbo.HathitrustResult");
            DropIndex("dbo.HathitrustResultLink", new[] { "HathitrustResultId" });
            DropTable("dbo.HathitrustResultLink");
            DropTable("dbo.HathitrustResult");
        }

        public override void Up()
        {
            CreateTable(
                "dbo.HathitrustResult",
                c => new
                {
                    Id = c.Int(false, true),
                    Author = c.String(),
                    BookId = c.Int(false),
                    Description = c.String(),
                    Language = c.String(),
                    Publisher = c.String(),
                    Url = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.HathitrustResultLink",
                c => new
                {
                    Id = c.Int(false, true),
                    HathitrustResultId = c.Int(false),
                    Url = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HathitrustResult", t => t.HathitrustResultId, true)
                .Index(t => t.HathitrustResultId);
        }
    }
}