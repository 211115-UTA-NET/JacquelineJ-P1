﻿using Project1WebApp.Models;

namespace Project1WebApp.Repository
{
    public interface IOrderDetailsRepository
    {
        List<OrderDetailsModel> getOrderDetails(string order_Id);
        List<OrderDetailsModel> getOrdersByStore(string storeId);
        public List<OrderDetailsModel> getOrdersByCustomer(string customerId);
    }
}