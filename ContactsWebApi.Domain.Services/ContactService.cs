using ContactsWebApi.Data.Interface;
using ContactsWebApi.Domain.Interface;
using ContactsWebApi.Domain.Model;
using System;
using System.Collections.Generic;

namespace ContactsWebApi.Domain.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository ?? throw new ArgumentNullException("contactRepository");
        }        

        public List<Contact> List()
        {
            try
            {
                return _contactRepository.List();
            }
            catch (Exception ex)
            {
                throw new ContactServiceException("ContactService.List threw an exception.", ex);
            }
        }

        public int Post(Contact contactToSave)
        {
            try
            {
                return _contactRepository.Post(contactToSave);
            }
            catch (Exception ex)
            {
                throw new ContactServiceException("ContactService.Post threw an exception.", ex);
            }
        }

        public int Put(Contact contactToUpdate)
        {
            try
            {
                return _contactRepository.Put(contactToUpdate);
            }
            catch (Exception ex)
            {
                throw new ContactServiceException("ContactService.Put threw an exception.", ex);
            }
        }

        public int Delete(int id)
        {
            try
            {
                return _contactRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new ContactServiceException("ContactService.Delete threw an exception.", ex);
            }
        }
    }
}
