using Contacts.Model;
using System.Data.Entity;

namespace Contacts.Repository
{
    public class ContactContext : DbContext
    {

        public ContactContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Contact> Contacts { get; set; }

    }
}
