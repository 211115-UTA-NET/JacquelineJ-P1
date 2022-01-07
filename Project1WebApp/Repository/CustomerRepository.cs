
using Project1WebApp.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1WebApp.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        public List<CustomerModel> getCustomers(string cusName)
        {
            Console.WriteLine("CustomerController : results : Fetching from Customer table");
            CustomerModel customerObject = new CustomerModel();
            DatabaseConnection objDB = new DatabaseConnection();
            SqlConnection connectionObj = objDB.DBConnection();
            List<CustomerModel> customerList = new List<CustomerModel>();

            string customerSelectQuery = "Select * from Customer";
            StringBuilder stringBuilderObj = new StringBuilder();
            stringBuilderObj.Append(customerSelectQuery);
            if (cusName != null && cusName.Length > 0)
            {
                stringBuilderObj.Append(" Where CustomerLastName = '" + cusName + "'");
            }
            string Query = stringBuilderObj.ToString();
            //Console.WriteLine("CustomerController : results : Fetching from Customer table" + Query);
            try
            {
                SqlDataReader reader = objDB.FetchProducts(Query, connectionObj);
                CustomerModel customerObj;

                using (reader)
                {
                    while (reader.Read())
                    {
                        customerObj = new CustomerModel();
                        customerObj.Customer_Id = reader.GetInt32(0);
                        customerObj.Customer_FirstName = reader.GetString(1);
                        customerObj.Customer_LastName = reader.GetString(2);
                        customerObj.Customer_City = reader.GetString(3);
                        customerObj.Customer_State = reader.GetString(4);
                        customerList.Add(customerObj);
                    }
                    //Console.WriteLine("Customer objects created :");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Query Not Executed : " + ex.Message);
            }
            finally { connectionObj.Close(); }
            return customerList;
        }
    }

}
