using Project1WebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1WebApp.Repository
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly IDBRepository _repository;
        public OrderDetailsRepository(IDBRepository repository)
        {
            _repository = repository;
        }
        public List<OrderDetailsModel> getOrderDetails(string order_Id)
        {
            //private List<ProductModel> products = new List<ProductModel>();
            Console.WriteLine("OrderDetailsRepository : results : Fetching from OrderdetailsTable table");

            SqlConnection connectionObj = _repository.DBConnection();
            List<OrderDetailsModel> orderDetailsList = new List<OrderDetailsModel>();

            Console.WriteLine("getting order details by orderId " + order_Id);

            using (connectionObj)
            {
                // Query to be executed
                string queryString = "SELECT o.OrderID, o.Cus_ID, c.CustomerFirstName, c.CustomerLastName,d.Pro_ID, d.Pro_Name, d.Quantity, s.StoreId, s.StoreName, o.Order_TIME "
                + "FROM order_ o, OrderDetails d, Customer c, Store s "
                + "WHERE o.OrderID = d.OrderID "
                + "and o.Cus_ID = c.CustomerId and d.Store_ID = s.StoreId ";

                StringBuilder stringbuilderObject = new StringBuilder();
                stringbuilderObject.Append(queryString);
                SqlCommand command;
                if (order_Id != null && order_Id.Length > 0)
                {
                    int id = Convert.ToInt32(order_Id);
                    stringbuilderObject.Append(" and o.orderid = @orderId");
                    command = new SqlCommand(stringbuilderObject.ToString(), connectionObj);
                    command.Parameters.AddWithValue("@orderId", id);
                }
                else
                {
                    command = new SqlCommand(queryString, connectionObj);
                }

                Console.WriteLine("OrderController : Query : ");
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    orderDetailsList = getOrdersAsList(reader);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Query Not Executed : " + ex.Message);
                }
                finally { connectionObj.Close(); }
                
            }
            return orderDetailsList;
        }

        public List<OrderDetailsModel> getOrdersByStore(int storeId)
        {
            Console.WriteLine("getOrdersByStore -- " + storeId);
            SqlConnection connectionObj = _repository.DBConnection();

            List<OrderDetailsModel> orderDetailsList = new List<OrderDetailsModel>();
            using (connectionObj)
            {
                // Query to be executed
                string queryString = "SELECT o.OrderID, o.Cus_ID, c.CustomerFirstName, c.CustomerLastName,d.Pro_ID, d.Pro_Name, d.Quantity, s.StoreId, s.StoreName, o.Order_TIME "
                + "FROM order_ o, OrderDetails d, Customer c, Store s "
                + "WHERE o.OrderID = d.OrderID "
                + "and o.Cus_ID = c.CustomerId and d.Store_ID = s.StoreId ";

                StringBuilder stringbuilderObject = new StringBuilder();
                stringbuilderObject.Append(queryString);
                SqlCommand command;
                if (storeId > 0)
                {
                    stringbuilderObject.Append(" and s.StoreId = @StoreId");
                    command = new SqlCommand(stringbuilderObject.ToString(), connectionObj);
                    command.Parameters.AddWithValue("@StoreId", storeId);
                }
                else
                {
                    command = new SqlCommand(queryString, connectionObj);
                }
                
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    orderDetailsList = getOrdersAsList(reader);                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Query Not Executed : " + ex.Message);
                }
                finally { connectionObj.Close(); }
                
            }
            return orderDetailsList;
        }
 
        public List<OrderDetailsModel> getOrdersByCustomer(string customerId)
        {
            Console.WriteLine("getting order details by orderId " + customerId);
            SqlConnection connectionObj = _repository.DBConnection();

            List<OrderDetailsModel> orderDetailsList = new List<OrderDetailsModel>();
            using (connectionObj)
            {
                // Query to be executed
                string queryString = "SELECT o.OrderID, o.Cus_ID, c.CustomerFirstName, c.CustomerLastName,d.Pro_ID, d.Pro_Name, d.Quantity, s.StoreId, s.StoreName, o.Order_TIME "
                + "FROM order_ o, OrderDetails d, Customer c, Store s "
                + "WHERE o.OrderID = d.OrderID "
                + "and o.Cus_ID = c.CustomerId and d.Store_ID = s.StoreId ";

                StringBuilder stringbuilderObject = new StringBuilder();
                stringbuilderObject.Append(queryString);
                SqlCommand command;
                if (customerId != null)
                {
                    int id = Convert.ToInt32(customerId);
                    stringbuilderObject.Append(" and c.CustomerId = @customerId");
                    command = new SqlCommand(stringbuilderObject.ToString(), connectionObj);
                    command.Parameters.AddWithValue("@customerId", customerId);
                }
                else
                {
                    command = new SqlCommand(queryString, connectionObj);
                }

                Console.WriteLine("OrderController : Query : ");
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    orderDetailsList = getOrdersAsList(reader);                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Query Not Executed : " + ex.Message);
                }
                finally { connectionObj.Close(); }                
            }
            return orderDetailsList;
        }

        private List<OrderDetailsModel> getOrdersAsList(SqlDataReader reader)
        {
            List<OrderDetailsModel> orderDetails = new List<OrderDetailsModel>();
            OrderDetailsModel orderObj = null;
            while (reader.Read())
            {
                orderObj = new OrderDetailsModel();
                orderObj.Order_Id = reader.GetInt32(0);
                orderObj.Cust_Id = reader.GetInt32(1);
                orderObj.Cust_FName = reader.GetString(2);
                orderObj.Cust_LName = reader.GetString(3);
                orderObj.Prod_Id = reader.GetInt32(4);
                orderObj.Prod_Name = reader.GetString(5);
                orderObj.Prod_Quantity = reader.GetInt32(6);
                orderObj.Store_Id = reader.GetInt32(7);
                orderObj.Store_Name = reader.GetString(8);
                orderObj.Order_Time = reader.GetDateTime(9);
                orderDetails.Add(orderObj);
            }
            return orderDetails;
        }
    }
}
