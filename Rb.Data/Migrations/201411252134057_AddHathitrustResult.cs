namespace Rb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHathitrustResult : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HathitrustResult",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        BookId = c.Int(nullable: false),
                        Description = c.String(),
                        Language = c.String(),
                        Publisher = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HathitrustResultLink",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HathitrustResultId = c.Int(nullable: false),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HathitrustResult", t => t.HathitrustResultId, cascadeDelete: true)
                .Index(t => t.HathitrustResultId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HathitrustResultLink", "HathitrustResultId", "dbo.HathitrustResult");
            DropIndex("dbo.HathitrustResultLink", new[] { "HathitrustResultId" });
            DropTable("dbo.HathitrustResultLink");
            DropTable("dbo.HathitrustResult");
        }
    }
}
