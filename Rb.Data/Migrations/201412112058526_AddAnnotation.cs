namespace Rb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "Annotation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "Annotation");
        }
    }
}
