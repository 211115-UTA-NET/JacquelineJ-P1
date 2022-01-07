using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1WebApp.Repository
{
    public class DatabaseConnection
    {
        private string sqlProperties()
        {
            StringBuilder stringbuilderObject = new StringBuilder();
            string path = "C:\\Users\\ashwi\\OneDrive\\Desktop\\.NET\\PROJECT0\\DBproperties.txt";
            StreamReader reader = new StreamReader(path);
            stringbuilderObject.Append("Data Source=2111-sql-jack.database.windows.net;Initial Catalog=jackie_Project0DB;Persist Security Info=False;User ID=");
            stringbuilderObject.Append(reader.ReadLine());
            stringbuilderObject.Append("; Password =");
            stringbuilderObject.Append(reader.ReadLine());
            reader.Close();
            string connectStr = stringbuilderObject.ToString();
            return (connectStr);
        }

        public SqlConnection DBConnection()
        {

            string connectString = sqlProperties();
            SqlConnection conn = new SqlConnection(connectString);
            try
            {
                //Console.WriteLine("Connecting to databse...");
                conn.Open();
                //Console.WriteLine("Connected Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not connected because of the error : ", ex.Message);
            }
            return conn;
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

    }
}

