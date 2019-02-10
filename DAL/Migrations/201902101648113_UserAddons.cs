namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class UserAddons : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, defaultValue: ""));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, defaultValue: ""));
        }

        public override void Down()
        {

        }
    }
}
