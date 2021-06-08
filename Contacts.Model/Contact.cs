using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Model
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter First name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Phone Number.")]
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
    }
}
