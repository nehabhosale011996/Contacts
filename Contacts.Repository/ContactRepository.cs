using Contacts.Model;
using Contacts.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;

namespace Contacts.Repository
{

    public class ContactRepository : IContactRepository
    {
        private readonly ContactContext _context;
        public ContactRepository(ContactContext ContactContext)
        {
            _context = ContactContext;
            Database.SetInitializer(new NullDatabaseInitializer<ContactContext>());
        }

        public List<Contact> Get()
        {
            try
            {
                List<Contact> contacts = _context.Contacts.ToList();
                return contacts;
            }
            catch (EntityException exception)
            {
                throw new Exception("Problem Occured while Retrieving Contacts", exception);
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        public int Add(Contact contact)
        {
            try
            {

                if (_context.Contacts.Any(i => i.Email == contact.Email))
                    throw new ContactException("Email is not unique");

                if (_context.Contacts.Any(i => i.PhoneNumber == contact.PhoneNumber))
                    throw new ContactException("Phone number is not unique");
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return contact.Id;
            }
            catch (EntityException exception)
            {
                throw exception;
            }
            catch (ArgumentException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        public ContactStatus Edit(Contact contact)
        {
            try
            {
                var result = _context.Contacts.SingleOrDefault(x => x.Id == contact.Id);

                if (result != null)
                {
                    if (result.Email != contact.Email)
                    {
                        throw new ContactException("Email should be unique");
                    }
                    if (result.PhoneNumber != contact.PhoneNumber)
                    {
                        throw new ContactException("Email should be unique");
                    }

                    result.FirstName = contact.FirstName;
                    result.LastName = contact.LastName;
                    result.Email = contact.Email;
                    result.PhoneNumber = contact.PhoneNumber;
                    result.Status = contact.Status;

                    _context.SaveChanges();
                    return ContactStatus.SUCCESS;
                }
                throw new ContactException("There is no such contact");
            }
            catch (EntityException exception)
            {
                throw exception;
            }

            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
