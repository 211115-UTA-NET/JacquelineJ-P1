using Project1WebApp.Models;
using Project1WebApp.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Project1WebApp.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public List<OrderModel> getOrder(int order_Id)
        {
            //private List<ProductModel> products = new List<ProductModel>();
            Console.WriteLine("OrderController : results : Fetching from Order table");
            OrderModel orderObject = new OrderModel();
            DatabaseConnection objDB = new DatabaseConnection();
            SqlConnection connectionObj = objDB.DBConnection();
            List<OrderModel> orderList = new List<OrderModel>();

            string customerSelectQuery = "Select * from Order_";
            StringBuilder stringBuilderObj = new StringBuilder();
            stringBuilderObj.Append(customerSelectQuery);
            if (order_Id != 0)
            {
                stringBuilderObj.Append(" Where orderid = '" + order_Id + "'");
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

                        orderObject = new OrderModel();
                        orderObject.Order_Id = reader.GetInt32(0);
                        orderObject.Cust_Id = reader.GetInt32(1);
                        orderObject.Order_Time = reader.GetDateTime(2);                        
                        orderList.Add(orderObject);
                    }                   

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Query Not Executed : " + ex.Message);
            }
            finally { connectionObj.Close(); }
            return orderList;
        }


        public int addOrder(List<OrderRequest> orderRequests)
        {
            Console.WriteLine("In order add ");

            OrderRequest orderReq = null;
            DatabaseConnection objDB = new DatabaseConnection();
            SqlConnection connectionObj = objDB.DBConnection();
            int newOrderId = 0;
            Boolean orderIdCreated = false;

            using (connectionObj)
            {
                Console.WriteLine("Enter Customer data ");
                // Query to be executed

                string queryString = "Insert into OrderDetails (OrderID,Pro_ID,Pro_Name,Store_ID,Quantity) Values "
                    + "(@OrderID,@Pro_ID,@Pro_Name,@Store_ID,@Quantity)";
                try
                {
                    for (int i = 0; i < orderRequests.Count; i++)
                    {
                        orderReq = orderRequests[i];
                        if (!orderIdCreated) { 
                            newOrderId = addToOrder(orderReq.Cus_Id);
                            orderIdCreated = true;
                        }
                        SqlCommand command = new SqlCommand(queryString, connectionObj);
                        command.Parameters.AddWithValue("@OrderID", newOrderId);
                        command.Parameters.AddWithValue("@Pro_ID", orderReq.Pro_ID);
                        command.Parameters.AddWithValue("@Pro_Name", orderReq.Pro_Name);
                        command.Parameters.AddWithValue("@Store_ID", orderReq.Store_Id);
                        command.Parameters.AddWithValue("@Quantity", orderReq.Quantity);
                    
                        command.ExecuteNonQuery();
                        Console.WriteLine("ExecuteNonQuery");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
                finally { connectionObj.Close(); }
            }
            return newOrderId;
        }

 /*
    private void updatePrdQuantity()
        {
            //PLACE ORDER BY UPDATE PRODUCT TABLE, INSERT ORDER TABLE AND INSERT ORDERDETAILS TABLE
            //UPDATE PRODUCT TABLE
        IProductRepository productRepo = new IProductRepository();

            int currentProductQuantity = getNewProdQuantity(productList, product_Id);
            String selectedProductName = getProdName(productList, product_Id);

            int prod_NewQuantity = currentProductQuantity - product_Quantity;
            if (prod_NewQuantity > 0)
            {
                productRepo.updateProductQuantity(product_Id, prod_NewQuantity);
            }
        }

        private int getNewProdQuantity(List<Product> productList, int product_Id)
        {
            foreach (Product item in productList)
            {
                if (item.ProductId == product_Id)
                    return item.ProductQuantity;
            }
            return 0;
        }

        private string getProdName(List<Product> productList, int product_Id)
        {
            foreach (Product item in productList)
            {
                if (item.ProductId == product_Id)
                    return item.ProductName;
            }
            return null;
        }
        */
        public int addToOrder(int customerId)
        {
            DatabaseConnection objDB = new DatabaseConnection();
            SqlConnection connectionObj = objDB.DBConnection();
            Console.WriteLine("In OrdereController - addToOrder ");

            int orderId = 0;
            using (connectionObj)
            {

                // Query to be executed
                string queryString = "Insert into Order_ (Cus_ID) Values "
                 + "(@Cus_ID)";
                queryString += " SELECT SCOPE_IDENTITY()";
                SqlCommand command = new SqlCommand(queryString, connectionObj);
                command.Parameters.AddWithValue("@Cus_ID", customerId);
                SqlParameter orderedId = new SqlParameter("@OrderID", SqlDbType.Int);
                orderedId.Direction = ParameterDirection.Output;
                command.Parameters.Add(orderedId);

                Console.WriteLine("OrderController addOrder query : " + queryString);
                try
                {
                    orderId = Convert.ToInt32(command.ExecuteScalar());
                    //command.ExecuteNonQuery();                   
                    Console.WriteLine("OrderController addOrder - ExecuteScalar - orderId: " + orderId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connectionObj.Close();
                }
            }
            return orderId;
        }

    }
}

