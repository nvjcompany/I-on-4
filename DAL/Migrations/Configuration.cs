namespace DAL.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Database.IesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DAL.Database.IesDbContext";
        }

        protected override void Seed(DAL.Database.IesDbContext context)
        {
            context.Roles.Add(new IdentityRole() { Name = "Administrator" });
            context.Roles.Add(new IdentityRole() { Name = "Company" });
            context.Roles.Add(new IdentityRole() { Name = "Student" });
            context.SaveChanges();
        }
    }
}
