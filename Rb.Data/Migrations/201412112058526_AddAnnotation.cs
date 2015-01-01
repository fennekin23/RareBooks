using System.Data.Entity.Migrations;

namespace Rb.Data.Migrations
{
    public partial class AddAnnotation : DbMigration
    {
        public override void Down()
        {
            DropColumn("dbo.Book", "Annotation");
        }

        public override void Up()
        {
            AddColumn("dbo.Book", "Annotation", c => c.String());
        }
    }
}