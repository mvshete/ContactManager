using ContactsWebApi.Data.Helper;
using ContactsWebApi.Data.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ContactsWebApi.Data.Repository
{
    public class Database : IDatabase
    {
        public List<T> List<T>(string sql)
        {
            var reader = SqlHelper.ExecuteReader(ConnectionString, sql, CommandType.StoredProcedure, null);
            return DataReaderMapToList<T>(reader);
        }

        public void Save(string query, SqlParameter[] sqlParams)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString, query, CommandType.StoredProcedure, sqlParams);
        }       

        public void Update(string query, SqlParameter[] sqlParams)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString, query, CommandType.StoredProcedure, sqlParams);
        }

        public void Delete(string query, SqlParameter[] sqlParams)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString, query, CommandType.StoredProcedure, sqlParams);
        }                       

        public List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            var list = new List<T>();
            while (dr.Read())
            {
                var obj = Activator.CreateInstance<T>();
                foreach (var prop in obj.GetType().GetProperties().Where(prop => !Equals(dr[prop.Name], DBNull.Value)))
                {
                    prop.SetValue(obj, dr[prop.Name], null);
                }
                list.Add(obj);
            }
            return list;
        }

        private string _connectionString;

        private Database()
        {
            _connectionString = null;
        }

        public static IDatabase Instance { get; } = new Database();

        private readonly object _connectionStringLock = new object();

        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    lock (_connectionStringLock)
                        if (string.IsNullOrEmpty(_connectionString))
                        {
                            string connStr;
                            if (GetConnectionFromAppConfig(out connStr))
                            {
                                _connectionString = connStr;
                            }
                            else
                            {
                                throw new NullReferenceException("Connection String Property has not been set.");
                            }
                        }
                }

                return _connectionString;
            }
        }

        private static bool GetConnectionFromAppConfig(out string connectionString)
        {
            connectionString = string.Empty;

            if (ConfigurationManager.AppSettings["ConnectionString"] == null ||
                ConfigurationManager.AppSettings["ConnectionString"] == string.Empty) return false;
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            return true;
        }

        public void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
            
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                }
            }
            catch (SqlException)
            {
                _connectionString = null;
            }
        }

    }
}
