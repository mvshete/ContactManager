using ContactsWebApi.Domain.Model;
using System.Collections.Generic;

namespace ContactsWebApi.Data.Interface
{
    public interface IContactRepository
    {             
        List<Contact> List();
        int Post(Contact contact);
        int Put(Contact contactToUpdate);
        int Delete(int id);
    }
}
