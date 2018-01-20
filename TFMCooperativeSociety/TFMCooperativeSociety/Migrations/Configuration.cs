namespace TFMCooperativeSociety.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TFMCooperativeDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TFMCooperativeDB context)
        {
            if (!context.Roles.Any(r => r.Name == "Administrators"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Administrators" };

                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Members"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Members" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "ogbosukachris@TFMCooperative.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "ogbosukachris@TFMCooperative.com" ,
                    Email = "ogbosukachris@TFMCooperative.com",
                    EmailConfirmed = true ,
                    FirstName ="Chris" ,
                    LastName ="Ogbosuka"
                };

                manager.Create(user, "admin12345");
                manager.AddToRole(user.Id, "Administrators");
            }


            if (!context.Users.Any(u => u.UserName == "ebukavictor@TFMCooperative.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "ebukavictor@TFMCooperative.com",
                    Email = "ebukavictor@TFMCooperative.com",
                    EmailConfirmed = true ,
                    FirstName = "Ebuka" ,
                    LastName ="Victor"
                };

                manager.Create(user, "admin12345");
                manager.AddToRole(user.Id, "Administrators");
            }


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
