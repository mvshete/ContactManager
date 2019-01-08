using ContactsWebApi.Data.Model;
using ContactsWebApi.Domain.Model;
using System.Collections.Generic;

namespace ContactsWebApi.Data.Mapper
{
    public class ContactMapper
    {
        public static List<Contact> MapToContactList(List<ContactResult> contactList)
        {
            var list = new List<Contact>();
            foreach (var contact in contactList)
            {
                var c = new Contact
                {
                    Id = contact.Id,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Email = contact.Email,
                    Phone = contact.Phone,
                    Status = contact.Status
                };
                list.Add(c);
            }

            return list;
        }
    }
}
