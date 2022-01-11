
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

        private readonly IDBRepository _repository;

        public CustomerRepository(IDBRepository repository)
        {
            _repository = repository;
        }

        public List<CustomerModel> getCustomers(string cusName)
        {
            Console.WriteLine("CustomerController : results : Fetching from Customer table");
            CustomerModel customerObject = new CustomerModel();
            SqlConnection connectionObj = _repository.DBConnection();

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
                SqlDataReader reader = _repository.FetchProducts(Query, connectionObj);
                CustomerModel customerObj;

                using (reader)
                {
                    while (reader.Read())
                    {
                        customerObj = new CustomerModel();
                        customerObj.CustomerId = reader.GetInt32(0);
                        customerObj.CustomerFirstName = reader.GetString(1);
                        customerObj.CustomerLastName = reader.GetString(2);
                        customerObj.C_Address1 = reader.GetString(3);
                        customerObj.C_Address2 = reader.GetString(4);
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
            Console.WriteLine("In Customer add ");

            CustomerModel customerObject = new CustomerModel();            
            SqlConnection connectionObj = _repository.DBConnection();
            using (connectionObj)
            {
                Console.WriteLine("Enter Customer data ");
                // Query to be executed
                string queryString = "Insert into Customer (CustomerFirstName,CustomerLastName,C_Address1,C_Address2) Values "
                    + "(@customerFirstName,@customerLastName,@c_Address1,@c_Address2)";

                SqlCommand command = new SqlCommand(queryString, connectionObj);
                command.Parameters.AddWithValue("@customerFirstName", customer.CustomerFirstName);
                command.Parameters.AddWithValue("@customerLastName", customer.CustomerLastName);
                command.Parameters.AddWithValue("@c_Address1", customer.C_Address1);
                command.Parameters.AddWithValue("@c_Address2", customer.C_Address2);
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
