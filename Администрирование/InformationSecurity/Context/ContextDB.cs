using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSecurity.Context
{
    public class ContextDB : DbContext
    {
        public ContextDB() : base("name=InfoSecureDB")
        {
            //Database.SetInitializer<ContextDB>(new CreateDatabaseIfNotExists<ContextDB>());
            //Database.SetInitializer<ContextDB>(new DropCreateDatabaseAlways<ContextDB>());
            Database.SetInitializer<ContextDB>(new MigrateDatabaseToLatestVersion<ContextDB, Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Models.Subject> Subjects { get; set; }

        public DbSet<Models.Role> Roles { get; set; }

        public DbSet<Models.Level> Levels { get; set; }

        public DbSet<Models.Ban> Bans { get; set; }

        public DbSet<Models.UnregisteredSubjects> UnregSubjects { get; set; }

    }
}
