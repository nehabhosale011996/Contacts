using System;

namespace Contacts.Repository
{
    public class ContactException : Exception
    {

        private static readonly string DefaultMessage = "An error occurred contact admin.";

        /// <summary>
        /// Creates a new <see cref="ContactException"/> with a predefined message.
        /// </summary>
        public ContactException() : base(DefaultMessage)
        {
        }

        /// <summary>
        /// Creates a new <see cref="ContactException"/> with a user-supplied message.
        /// </summary>
        public ContactException(string message) : base(message)
        {
        }

        /// <summary>
        /// Creates a new <see cref="ContactException"/> with a predefined message and a wrapped inner exception.
        /// </summary>
        public ContactException(Exception innerException)
            : base(DefaultMessage, innerException)
        {
        }

        /// <summary>
        /// Creates a new <see cref="ContactException"/> with a user-supplied message and a wrapped inner exception.
        /// </summary>
        public ContactException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
