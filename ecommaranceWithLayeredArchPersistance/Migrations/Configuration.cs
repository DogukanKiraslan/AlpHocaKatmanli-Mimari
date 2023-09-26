namespace ecommaranceWithLayeredArchPersistance.Migrations
{
    using ecommaranceWithLayeredArchDomain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ecommaranceWithLayeredArchPersistance.Content.ecommaranceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ecommaranceWithLayeredArchPersistance.Content.ecommaranceContext context)
        {
            context.Users.AddOrUpdate(x => x.ID, new User() { ID = Guid.NewGuid(), Name = "John", Surname = "Doe", Email = "deneme@hotmail.com", Password = "wrwE7SAVWjg=" });
        }
    }
}
