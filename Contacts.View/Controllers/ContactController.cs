using Contacts.Model;
using Contacts.Service;
using Contacts.View.Models;
using Contacts.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Contacts.View.Controllers
{

    public class ContactController : ApiController
    {


        private readonly IContactService _contactService;


        public ContactController(IContactService contactservice)
        {

            _contactService = contactservice;

        }

        [Route("contacts")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var contactDTO = _contactService.GetContacts();
            List<ContactView> contactView = new List<ContactView>();
            var contacts = contactDTO.Contacts;

            foreach (var contact in contacts)
            {
                contactView.Add(new ContactView()
                {
                    Id = contact.Id,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Email = contact.Email,
                    PhoneNumber = contact.PhoneNumber,
                    Status = contact.Status
                });
            }
            ContactViewModel contactViewModel = new ContactViewModel();
            contactViewModel.Contacts = contactView;

            return Ok(contactViewModel);
        }


        [HttpPost]
        [Route("contact/add")]

        public IHttpActionResult AddContact(ContactView contact)
        {
            AddContactView AddContact = new AddContactView();
            Dictionary<string, string> validationError =
                      new Dictionary<string, string>();
            var context = new ValidationContext(contact);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(contact, context, validationResults, true);
            if (!isValid)
            {
                AddContact.ContactId = -1;
                AddContact.Status = "FAILURE";
                foreach (var result in validationResults)
                {
                    List<string> match = result.MemberNames.ToList();
                    validationError.Add(match[0], result.ErrorMessage);
                }

                AddContact.validationError = validationError;
                return Ok(AddContact);
            }


            try
            {

                var contactid = _contactService.AddContact(contact);

                AddContact.ContactId = contactid;
                AddContact.Status = "SUCCESS";
                return Ok(AddContact);
            }
            catch (Exception exception)
            {
                AddContact.ContactId = -1;
                AddContact.Status = "FAILURE";
                validationError.Add("First name", exception.Message);
                AddContact.validationError = validationError;
                return Content(HttpStatusCode.BadRequest, AddContact);
            }

        }


        [HttpPut]
        [Route("contact/contacts/{contactid}")]
        public IHttpActionResult EditContact([FromBody] ContactView contact, int contactid)

        {
            var status = _contactService.EditContact(contact).ToString();
            EditContact editcontact = new EditContact();
            editcontact.Status = _contactService.EditContact(contact).ToString();
            return Ok(editcontact);
        }
    }
}