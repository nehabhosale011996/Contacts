using Contacts.Model;

namespace Contacts.Service
{
    public interface IContactService
    {
        int AddContact(ContactView contactView);
        ContactStatus EditContact(ContactView contactView);
        ContactDTO GetContacts();
    }
}

