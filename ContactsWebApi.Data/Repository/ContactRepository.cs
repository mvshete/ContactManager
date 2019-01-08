using ContactsWebApi.Data.Interface;
using ContactsWebApi.Data.Mapper;
using ContactsWebApi.Data.Model;
using ContactsWebApi.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ContactsWebApi.Data.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDatabase _database;
        private const string GetAllContacts = "dbo.usp_GetAllContacts";
        private const string CreateContact = "dbo.usp_CreateContact";
        private const string UpdateContact = "dbo.usp_UpdateContact";
        private const string DeleteContact = "dbo.usp_DeleteContact";

        public ContactRepository(IDatabase database)
        {
            _database = database ?? throw new ArgumentNullException("database");
        }

        public List<Contact> List()
        {
            return ContactMapper.MapToContactList(_database.List<ContactResult>(GetAllContacts));
        }       

        public int Post(Contact contact)
        {
            var returnValue = new SqlParameter("ReturnValue", DbType.Int32) { Direction = ParameterDirection.Output };

            var parameters = new[]
            {
                new SqlParameter("@FirstName", contact.FirstName),
                new SqlParameter("@LastName", contact.LastName),
                new SqlParameter("@Email", contact.Email),
                new SqlParameter("@Phone", contact.Phone),
                new SqlParameter("@Status", contact.Status),
                returnValue
            };

            _database.Save(CreateContact, parameters);

            return Convert.ToInt32(returnValue.Value);
        }
           
        public int Put(Contact contactToUpdate)
        {
            var returnValue = new SqlParameter("ReturnValue", DbType.Int32) { Direction = ParameterDirection.Output };

            var parameters = new[]
            {
                new SqlParameter("@Id", contactToUpdate.Id),
                new SqlParameter("@FirstName", contactToUpdate.FirstName),
                new SqlParameter("@LastName", contactToUpdate.LastName),
                new SqlParameter("@Email", contactToUpdate.Email),
                new SqlParameter("@Phone", contactToUpdate.Phone),
                new SqlParameter("@Status", contactToUpdate.Status),
                returnValue
            };

            _database.Update(UpdateContact, parameters);

            return Convert.ToInt32(returnValue.Value);
        }

        public int Delete(int id)
        {
            var returnValue = new SqlParameter("ReturnValue", DbType.Int32) { Direction = ParameterDirection.Output };

            var parameters = new[]
            {
                new SqlParameter("@Id", id),
                returnValue
            };

            _database.Delete(DeleteContact, parameters);

            return Convert.ToInt32(returnValue.Value);
        }
    }
}
