using System.Data.Entity.Migrations;

namespace Rb.Data.Migrations
{
    public partial class AddWorldcatResult : DbMigration
    {
        public override void Down()
        {
            DropTable("dbo.WorldcatResult");
        }

        public override void Up()
        {
            CreateTable(
                "dbo.WorldcatResult",
                c => new
                {
                    Id = c.Int(false, true),
                    BookId = c.Int(false),
                    Contents = c.String(),
                    Description = c.String(),
                    Genre = c.String(),
                    Notes = c.String(),
                    OtherTitles = c.String(),
                    Url = c.String(),
                })
                .PrimaryKey(t => t.Id);
        }
    }
}