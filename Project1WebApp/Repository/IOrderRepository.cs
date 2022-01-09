using Project1WebApp.Data;
using Project1WebApp.Models;

namespace Project1WebApp.Repository
{
    public interface IOrderRepository
    {
        public List<OrderModel> getOrder(int cust_Id);
        //public void addOrderNew();
        public int addOrder(List<OrderRequest> orderRequests);
    }
}