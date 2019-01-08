using System.Data;
using System.Data.SqlClient;

namespace ContactsWebApi.Data.Helper
{
    internal static class SqlHelper
    {
        public static int ExecuteNonQuery(string connectionString, string commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
      
        public static object ExecuteScalar(string connectionString, string commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
        
        public static SqlDataReader ExecuteReader(string connectionString, string commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                conn.Open();
                
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
               
            }
        }
    }
}