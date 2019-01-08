using System;

namespace ContactsWebApi.Domain.Services
{
    public class ContactServiceException : Exception
    {
        public ContactServiceException() {}

        public ContactServiceException(string message) : base(message) { }

        public ContactServiceException(string message, Exception innerException)
            : base(message, innerException) { }

    }
}
