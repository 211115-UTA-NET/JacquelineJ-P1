using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1WebApp.Repository
{
    public class DBRepository : IDBRepository
    {
        private readonly string _connectionString;

        public DBRepository(String connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection DBConnection()
        {
            //SqlConnection conn = new SqlConnection(connectString);
            //using SqlConnection conn = new(_connectionString);

            SqlConnection conn = new SqlConnection(_connectionString);
            try
            {
                //Console.WriteLine("Connecting to databse...");
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not connected because of the error : ", ex.Message);
            }
            return conn;
        }

        public SqlDataReader FetchProducts(string sqlQuery, SqlConnection conn)
        {
            SqlDataReader reader = null;
            if (conn is null || sqlQuery is null)
            {
                return null;
            }

            try
            {
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                Console.WriteLine("Sql query execution :" + sqlQuery);
                reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Query Not Executed : " + ex.Message);
            }

            return reader;

        }

        public string Insert(string sqlQuery, SqlConnection conn)
        {
            if (conn is null || sqlQuery is null)
            {
                return "do nothing as connection object is null";
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    Console.WriteLine("Sql query execution : ", sqlQuery);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Query Not Executed : ", ex.Message);
            }
            finally { conn.Close(); }

            return "Query Executed";
        }

    }
}
