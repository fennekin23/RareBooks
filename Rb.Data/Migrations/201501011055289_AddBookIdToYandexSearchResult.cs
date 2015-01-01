namespace Rb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookIdToYandexSearchResult : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.YandexSearchResult", "BookId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.YandexSearchResult", "BookId");
        }
    }
}
