
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
        public CustomerRepository()
        {
        }

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
            finally
            {
                connectionObj.Close();
            }
                return customerList;
        }

        public List<CustomerModel> addCustomerNew(CustomerModel customer)
        {
            //insert into Customer (CustomerFirstName, CustomerLastName, C_Address1, C_Address2) values
            //('Tom', 'Hanks', 'Enfield', 'CT');
            Console.WriteLine("In Customer add ");

            string firstName = customer.Customer_FirstName;
            string lastName = customer.Customer_LastName;
            string customer_City = customer.Customer_City;
            string customer_State = customer.Customer_State;

            CustomerModel customerObject = new CustomerModel();
            DatabaseConnection objDB = new DatabaseConnection();
            SqlConnection connectionObj = objDB.DBConnection();

            //SqlConnectionApp objDB = new SqlConnectionApp();
            //SqlConnection connectionObj = objDB.DBConnection();
            using (connectionObj)
            {
                Console.WriteLine("Enter Customer data ");
                // Query to be executed
                string queryString = "Insert into Customer (CustomerFirstName,CustomerLastName,C_Address1,C_Address2) Values "
                    + "(@cust_FirstName,@cust_LastName,@cust_AddressCity,@cust_AddressState)";

                SqlCommand command = new SqlCommand(queryString, connectionObj);
                command.Parameters.AddWithValue("@cust_FirstName", firstName);
                command.Parameters.AddWithValue("@cust_LastName", lastName);
                command.Parameters.AddWithValue("@cust_AddressCity", customer_City);
                command.Parameters.AddWithValue("@cust_AddressState", customer_State);
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
        
    }
}
