using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1WebApp.Data
{
    public class OrderRequest
    {
        public int OrderID { get; set; }
        public int Cus_Id { get; set; }
        public int Pro_ID { get; set; }
        public string Pro_Name { get; set; }
        public int Store_Id { get; set; }
        public int Quantity { get; set; }


    }
}
