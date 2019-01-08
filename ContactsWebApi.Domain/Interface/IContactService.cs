using ContactsWebApi.Domain.Model;
using System.Collections.Generic;

namespace ContactsWebApi.Domain.Interface
{
    public interface IContactService
    {
        List<Contact> List();
        int Post(Contact contactToSave);
        int Put(Contact contactToUpdate);
        int Delete(int id);
    }
}
