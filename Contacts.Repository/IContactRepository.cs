using Contacts.Model;
using System.Collections.Generic;

namespace Contacts.Repository
{
    public interface IContactRepository
    {
        List<Contact> Get();
        int Add(Contact contact);

        ContactStatus Edit(Contact contact);
    }

}
