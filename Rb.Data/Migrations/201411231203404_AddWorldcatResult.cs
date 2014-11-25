namespace Rb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWorldcatResult : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorldcatResult",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        Contents = c.String(),
                        Description = c.String(),
                        Genre = c.String(),
                        Notes = c.String(),
                        OtherTitles = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WorldcatResult");
        }
    }
}
