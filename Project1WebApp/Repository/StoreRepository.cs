using Project1WebApp.Models;
using System.Data.SqlClient;
using System.Text;

namespace Project1WebApp.Repository
{
    public class StoreRepository : IStoreRepository
    {

        private readonly IDBRepository _repository;

        public StoreRepository(IDBRepository repository)
        {
            _repository = repository;
        }
        public void addNewStore(StoreModel store)
        {
            Console.WriteLine("In Store add ");

            StoreModel storeObject = new StoreModel();
            SqlConnection connectionObj = _repository.DBConnection();

            using (connectionObj)
            {               
                string queryString = "Insert into Store (StoreId,StoreName,S_Address,ZipCode) Values "
                    + "(@storeId,@storeName,@s_Address,@zipCode)";

                SqlCommand command = new SqlCommand(queryString, connectionObj);
                command.Parameters.AddWithValue("@storeId", store.StoreId);
                command.Parameters.AddWithValue("@storeName", store.Name);               
                command.Parameters.AddWithValue("@s_Address", store.Address);
                command.Parameters.AddWithValue("@zipCode", store.Zipcode);
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
//            return null;
        }

        public StoreModel getStore(int storeId)
        {
            List<StoreModel> stores = getStores(storeId);
            StoreModel store = null; 
            if (stores.Count > 0)
            {
                store = stores[0];
            }
            return store;
        }

        public List<StoreModel> getAllStores()
        {
            return getStores(0);
        }

        private List<StoreModel> getStores(int storeId)
        {
            //private List<ProductModel> products = new List<ProductModel>();
            Console.WriteLine("StoreRepository : results : Fetching from Store table");
            StoreModel storeObject = new StoreModel();
            SqlConnection connectionObj = _repository.DBConnection();
            List<StoreModel> storeList = new List<StoreModel>();

            string storeSelectQuery = "Select * from Store";
            StringBuilder stringBuilderObj = new StringBuilder();
            stringBuilderObj.Append(storeSelectQuery);
            if (storeId > 0)
            {
                //int id = Convert.ToInt32(storeId);
                stringBuilderObj.Append(" Where StoreId = " + storeId + "");
            }
            string Query = stringBuilderObj.ToString();
            Console.WriteLine("CustomerController : results : Fetching from Customer table" + Query);
            try
            {
                SqlDataReader reader = _repository.FetchProducts(Query, connectionObj);

                using (reader)
                {
                    while (reader.Read())
                    {
                        storeObject = new StoreModel();
                        storeObject.StoreId = reader.GetInt32(0);
                        storeObject.Name = reader.GetString(1);
                        storeObject.Address = reader.GetString(2);
                        storeObject.Zipcode = reader.GetString(3);
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
