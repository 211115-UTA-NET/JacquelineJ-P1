using System.Data.SqlClient;

namespace Project1WebApp.Repository
{
    public interface IDBRepository
    {
        public SqlConnection DBConnection();
        public string Insert(string sqlQuery, SqlConnection conn);
        public SqlDataReader FetchProducts(string sqlQuery, SqlConnection conn);
    }
}