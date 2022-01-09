using Project1WebApp.Models;

namespace Project1WebApp.Repository
{
    public interface ICustomerRepository
    {
        public List<CustomerModel> getCustomers(string cusName);
        public List<CustomerModel> addCustomerNew(CustomerModel customer);
        //List<CustomerModel> addOrderNew(CustomerModel customer);
        //Task<List<CustomerModel>> GetAllBooksAsync(string cusName);
    }
}