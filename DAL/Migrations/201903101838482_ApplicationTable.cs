namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ListingId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Listings", t => t.ListingId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.ListingId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applications", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Applications", "ListingId", "dbo.Listings");
            DropIndex("dbo.Applications", new[] { "UserId" });
            DropIndex("dbo.Applications", new[] { "ListingId" });
            DropTable("dbo.Applications");
        }
    }
}
