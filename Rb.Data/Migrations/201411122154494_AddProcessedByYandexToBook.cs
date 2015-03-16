using System.Data.Entity.Migrations;

namespace Rb.Data.Migrations
{
    public partial class AddProcessedByYandexToBook : DbMigration
    {
        public override void Down()
        {
            DropColumn("dbo.Book", "ProcessedByYandex");
        }

        public override void Up()
        {
            AddColumn("dbo.Book", "ProcessedByYandex", c => c.Boolean(false));
        }
    }
}