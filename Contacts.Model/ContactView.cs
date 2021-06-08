using System.ComponentModel.DataAnnotations;

namespace Contacts.Model
{
    public class ContactView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter First name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Phone number.")]
        public string PhoneNumber { get; set; }

        public bool Status { get; set; }
    }
}
