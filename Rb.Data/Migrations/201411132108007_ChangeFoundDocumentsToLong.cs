namespace Rb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFoundDocumentsToLong : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.YandexSearchResult", "FoundDocuments", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.YandexSearchResult", "FoundDocuments", c => c.Int(nullable: false));
        }
    }
}
