using System.Collections.Generic;

namespace Contacts.WebApi.ViewModels
{
    public class AddContactView
    {
        public int ContactId { get; set; }
        public string Status { get; set; }
        public Dictionary<string, string> validationError { get; set; }
        public string SummaryError { get; set; }
        public AddContactView()
        {
            Status = "";

        }
    }

}
