namespace InformationSecurity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class Configuration : DbMigrationsConfiguration<InformationSecurity.Context.ContextDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "InformationSecurity.Context.ContextDB";
        }

        protected override void Seed(InformationSecurity.Context.ContextDB context)
        {
            context.Levels.AddOrUpdate(
                x => x.Name,
                new Models.Level { Name = "admin" }
                );

            context.Roles.AddOrUpdate(
                x => x.Name,
                new Models.Role { Name = "admin", Priority = 1, AllowedDays = "Sunday,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,"}
                );

            context.Subjects.AddOrUpdate(
                x => x.Login,
                new Models.Subject { Login = "ad", Password = "ad", AuthCount = 0, LevelId = 1, RoleId = 1 }
                );

            context.SaveChanges();
        }
    }
}
