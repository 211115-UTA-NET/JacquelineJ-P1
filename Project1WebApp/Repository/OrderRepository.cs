using Project1WebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1WebApp.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void addOrderNew()
        {
            throw new NotImplementedException();
        }

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
    }
}

