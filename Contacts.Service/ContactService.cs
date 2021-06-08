using Contacts.Model;
using Contacts.Repository;
using System;

namespace Contacts.Service
{
    public class ContactService : IContactService
    {

        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactListRepository)
        {
            _contactRepository = contactListRepository;
        }

        public ContactDTO GetContacts()
        {
            var contacts = _contactRepository.Get();

            ContactDTO contactDTO = new ContactDTO();
            contactDTO.Contacts = contacts;

            return contactDTO;
        }

        public int AddContact(ContactView contactView)
        {
            try
            {
                if (contactView.FirstName == null)
                {
                    throw new ArgumentNullException("First name");
                }
                if (contactView.LastName == null)
                {
                    throw new ArgumentNullException("Last name");
                }
                if (contactView.Email == null)
                {
                    throw new ArgumentNullException("Email");
                }
                if (contactView.PhoneNumber == null)
                {
                    throw new ArgumentNullException("Phone number");
                }

                Contact contact = new Contact();
                contact.FirstName = contactView.FirstName;
                contact.LastName = contactView.LastName;
                contact.Email = contactView.Email;
                contact.PhoneNumber = contactView.PhoneNumber;

                return _contactRepository.Add(contact);
            }
            catch (ArgumentNullException exception)
            {
                throw exception;

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ContactStatus EditContact(ContactView contactView)
        {
            Contact contact = new Contact();
            contact.Id = contactView.Id;
            contact.FirstName = contactView.FirstName;
            contact.LastName = contactView.LastName;
            contact.Email = contactView.Email;
            contact.PhoneNumber = contactView.PhoneNumber;
            return _contactRepository.Edit(contact);
        }
    }
}
