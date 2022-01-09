using Project1WebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1WebApp.Repository
{
    public class ProductRepository : IProductRepository
    {
        public List<ProductModel> getProducts(int storeId)
        {
            //private List<ProductModel> products = new List<ProductModel>();
            Console.WriteLine("CustomerController : results : Fetching from Customer table");
            ProductModel productObject = new ProductModel();
            DatabaseConnection objDB = new DatabaseConnection();
            SqlConnection connectionObj = objDB.DBConnection();
            List<ProductModel> productList = new List<ProductModel>();

            string customerSelectQuery = "Select * from Product";
            StringBuilder stringBuilderObj = new StringBuilder();
            stringBuilderObj.Append(customerSelectQuery);
            if (storeId != 0)
            {
                stringBuilderObj.Append(" Where storeId = '" + storeId + "'");
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

                        productObject = new ProductModel();
                        productObject.ProductId = reader.GetInt32(0);
                        productObject.ProductName = reader.GetString(1);
                        productObject.StoreId = reader.GetInt32(2);
                        productObject.ProductPrice = reader.GetDecimal(3);
                        productList.Add(productObject);
                    }
                    //Console.WriteLine("Customer objects created :");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Query Not Executed : " + ex.Message);
            }
            finally { connectionObj.Close(); }
            return productList;
        }

        public List<ProductModel> addNewProduct(ProductModel product)
        {
            //insert into Customer (CustomerFirstName, CustomerLastName, C_Address1, C_Address2) values
            //('Tom', 'Hanks', 'Enfield', 'CT');
            Console.WriteLine("In Product add ");
           
            int productId = product.ProductId;
            string productName = product.ProductName;
            int storeId = product.StoreId;
            decimal productPrice = product.ProductPrice;
            int productQuantity = product.ProductQuantity;

            ProductModel productObject = new ProductModel();
            DatabaseConnection objDB = new DatabaseConnection();
            SqlConnection connectionObj = objDB.DBConnection();

           
            using (connectionObj)
            {
                Console.WriteLine("Enter Product data ");
                // Query to be executed
                string queryString = "Insert into Product (ProductID,ProductName,StoreId,ProductPrice,ProductQuantity) Values "
                    + "(@productId,@productName,@storeId,@productPrice,@productQuantity)";

                SqlCommand command = new SqlCommand(queryString, connectionObj);
                command.Parameters.AddWithValue("@productId", productId);
                command.Parameters.AddWithValue("@productName", productName);
                command.Parameters.AddWithValue("@storeId", storeId);
                command.Parameters.AddWithValue("@productPrice", productPrice);
                command.Parameters.AddWithValue("@productQuantity", productQuantity);
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

        public List<ProductModel> updateProductQuantity(int ProductId, int ProductQuantity)
        {
            Console.WriteLine("Inside updateProductQuantity... productId-" + ProductId + " : Quantity-" + ProductQuantity);
            ProductModel productObject = new ProductModel();
            DatabaseConnection objDB = new DatabaseConnection();
            SqlConnection connectionObj = objDB.DBConnection();

            StringBuilder stringbuilderObject = new StringBuilder();
            stringbuilderObject.Append("update Product set ProductQuantity = @productQuantity");
            stringbuilderObject.Append(" where productid = @productId");
            string sqlQuery = stringbuilderObject.ToString();
            SqlCommand command = new SqlCommand(sqlQuery, connectionObj);
            command.Parameters.AddWithValue("@productQuantity", ProductQuantity);
            command.Parameters.AddWithValue("@productId", ProductId);
            Console.WriteLine("updateProductQuantity - Query - " + sqlQuery);

            try
            {
                command.ExecuteNonQuery();
                Console.WriteLine("updateProductQuantity - ExecuteNonQuery Complete");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connectionObj.Close(); }
            return null;

        }
    }

}
       