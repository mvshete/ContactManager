using ContactsWebApi.Data.Model;
using System.Collections.Generic;

namespace ContactsWebApi.Data.Tests
{
    public class ContactTestBase
    {
        protected List<ContactResult> contactsList;

        public virtual void SetUp()
        {
            contactsList = new List<ContactResult>
            {
                new ContactResult
                {
                    Id =1 ,
                    FirstName ="Ajay",
                    LastName = "Patil",
                    Email ="ajay.patil@gmail.com",
                    Phone="9000000000",
                    Status = true
                },

                new ContactResult
                {
                    Id =2 ,
                    FirstName ="Vinay",
                    LastName = "Jain",
                    Email ="vinay.jain@gmail.com",
                    Phone="9100000000",
                    Status = false
                },
                new ContactResult
                {
                    Id =3 ,
                    FirstName ="Ravi",
                    LastName = "Verma",
                    Email ="ravi.verma@gmail.com",
                    Phone="9200000000",
                    Status = true
                }
            };
        }
    }
}
