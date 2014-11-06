using System.Data.Entity.Migrations;

namespace Rb.Data.Migrations
{
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                {
                    Id = c.Int(false, true),
                    Author = c.String(),
                    Bbk = c.String(),
                    InternalId = c.Int(false),
                    Isbn = c.String(),
                    Issn = c.String(),
                    LanguageCode = c.Int(false),
                    Publisher = c.String(),
                    PublishPlace = c.String(),
                    PublishYear = c.Int(false),
                    Size = c.String(),
                    Title = c.String(),
                    Udk = c.String(),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Book");
        }
    }
}