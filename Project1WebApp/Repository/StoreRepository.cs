using Project1WebApp.Models;
using System.Data.SqlClient;
using System.Text;

namespace Project1WebApp.Repository
{
    public class StoreRepository : IStoreRepository
    {
        public List<StoreModel> addNewStore(StoreModel store)
        {
            Console.WriteLine("In Store add ");

            int storeId = store.StoreId;
            string storeName = store.StoreName;
            string s_Address = store.S_Address;           
            int zipCode = store.ZipCode;

            StoreModel storeObject = new StoreModel();
            DatabaseConnection objDB = new DatabaseConnection();
            SqlConnection connectionObj = objDB.DBConnection();

            using (connectionObj)
            {
                Console.WriteLine("Enter Product data ");
               
                string queryString = "Insert into Store (StoreId,StoreName,S_Address,ZipCode) Values "
                    + "(@storeId,@storeName,@s_Address,@zipCode)";

                SqlCommand command = new SqlCommand(queryString, connectionObj);
                command.Parameters.AddWithValue("@storeId", storeId);
                command.Parameters.AddWithValue("@storeName", storeName);               
                command.Parameters.AddWithValue("@s_Address", s_Address);
                command.Parameters.AddWithValue("@zipCode", zipCode);
                try
                {

                    command.ExecuteNonQuery();
                    Console.WriteLine("ExecuteNonQuery");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
                finally { connectionObj.Close(); }
            }
            return null;
        }

        public List<StoreModel> getStores(int storeId)
        {
            //private List<ProductModel> products = new List<ProductModel>();
            Console.WriteLine("StoreRepository : results : Fetching from Store table");
            StoreModel storeObject = new StoreModel();
            DatabaseConnection objDB = new DatabaseConnection();
            SqlConnection connectionObj = objDB.DBConnection();
            List<StoreModel> storeList = new List<StoreModel>();

            string storeSelectQuery = "Select * from Store";
            StringBuilder stringBuilderObj = new StringBuilder();
            stringBuilderObj.Append(storeSelectQuery);
            if (storeId != 0)
            {
                int id = Convert.ToInt32(storeId);
                stringBuilderObj.Append(" Where StoreId = " + storeId + "");
            }
            string Query = stringBuilderObj.ToString();
            //Console.WriteLine("CustomerController : results : Fetching from Customer table" + Query);
            try
            {
                SqlDataReader reader = objDB.FetchProducts(Query, connectionObj);


                using (reader)
                {
                    while (reader.Read())
                    {

                        storeObject = new StoreModel();
                        storeObject.StoreId = reader.GetInt32(0);
                        storeObject.StoreName = reader.GetString(1);
                        storeObject.S_Address = reader.GetString(2);
                        storeObject.ZipCode = reader.GetInt32(3);
                        storeList.Add(storeObject);
                    }
                    //Console.WriteLine("Customer objects created :");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Query Not Executed : " + ex.Message);
            }
            finally { connectionObj.Close(); }
            return storeList;
        }

    }
}
