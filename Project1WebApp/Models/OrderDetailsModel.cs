using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1WebApp.Models
{
    public class OrderDetailsModel
    {
        public int Order_Id { get; set;}
        public int Cust_Id { get; set;}
        public string? Cust_FName { get; set; }
        public string? Cust_LName { get; set; }
        public int Prod_Id { get; set; }
        public string? Prod_Name { get; set; }
        public int Prod_Quantity { get; set; }
        public int Store_Id { get; set; }
        public string? Store_Name { get; set; }
        public DateTime Order_Time { get; set; }
    }
}
