namespace Rb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameInYandexSearchResult : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.YandexSearchResult", "BookId", "BookInternalId");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.YandexSearchResult", "BookInternalId", "BookId");
        }
    }
}
