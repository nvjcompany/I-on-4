namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumns : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campaigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsActiveRegistration = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Listings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        CampaignId = c.Int(nullable: false),
                        TotalPositions = c.Int(nullable: false),
                        RegisterFrom = c.DateTime(nullable: false),
                        RegisterTo = c.DateTime(nullable: false),
                        CityId = c.Int(),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campaigns", t => t.CampaignId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CampaignId)
                .Index(t => t.CityId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.String(maxLength: 128),
                        CityId = c.Int(),
                        Bulstat = c.String(),
                        Logo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.AspNetUsers", t => t.OwnerId)
                .Index(t => t.OwnerId)
                .Index(t => t.CityId);
            
            AddColumn("dbo.AspNetUsers", "FNum", c => c.String());
            AddColumn("dbo.AspNetUsers", "Grade", c => c.Double());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Listings", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Listings", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Companies", "OwnerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Companies", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Listings", "CampaignId", "dbo.Campaigns");
            DropIndex("dbo.Companies", new[] { "CityId" });
            DropIndex("dbo.Companies", new[] { "OwnerId" });
            DropIndex("dbo.Listings", new[] { "CompanyId" });
            DropIndex("dbo.Listings", new[] { "CityId" });
            DropIndex("dbo.Listings", new[] { "CampaignId" });
            DropColumn("dbo.AspNetUsers", "Grade");
            DropColumn("dbo.AspNetUsers", "FNum");
            DropTable("dbo.Companies");
            DropTable("dbo.Cities");
            DropTable("dbo.Listings");
            DropTable("dbo.Campaigns");
        }
    }
}
