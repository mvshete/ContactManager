using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsWebApi.Helper
{
    public class CustomRoutes
    {
        public static class ContactRoute
        {
            public const string List = "api/contacts";
            public const string Post = "api/contact/new";
            public const string Put = "api/contact/update/{id}";
            public const string Delete = "api/contact/delete/{id}";
        }
    }
}