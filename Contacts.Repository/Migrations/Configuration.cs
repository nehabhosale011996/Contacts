using System.Data.Entity.Migrations;

namespace Contacts.Repository.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ContactContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Contacts.Repository.ContactContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
