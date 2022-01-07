using Project1WebApp.Models;

namespace Project1WebApp.Repository
{
    public interface ICustomerRepository
    {
        List<CustomerModel> getCustomers(string cusName);
    }
}