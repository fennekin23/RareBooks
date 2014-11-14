namespace Rb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUnknownRequestAndDocumentUrlForYandexResult : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.YandexSearchResult", "DocumentUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.YandexSearchResult", "DocumentUrl");
        }
    }
}
