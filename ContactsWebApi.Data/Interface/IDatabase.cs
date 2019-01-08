using System.Collections.Generic;
using System.Data.SqlClient;

namespace ContactsWebApi.Data.Interface
{
    public interface IDatabase
    {
        void SetConnectionString(string connectionString);        

        List<T> List<T>(string sql);
        void Save(string query, SqlParameter[] sqlParams);
        void Update(string query, SqlParameter[] sqlParams);              
        void Delete(string deleteContact, SqlParameter[] parameters);
        
    }
}