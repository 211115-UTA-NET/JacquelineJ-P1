using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1WebApp.Models
{
    public class OrderModel
    {
        public int Order_Id { get; set; }
        public int Cust_Id { get; set; }
        public DateTime Order_Time { get; set; }
    }
}
