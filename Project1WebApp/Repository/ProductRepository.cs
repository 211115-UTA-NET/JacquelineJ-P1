using Project1WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1WebApp.Repository
{
    public class ProductRepository : IProductRepository
    {
        private List<ProductModel> products = new List<ProductModel>();
        public int AddProduct(ProductModel product)
        {
            product.Id = products.Count + 1;
            products.Add(product);
            return product.Id;

        }

        public List<ProductModel> GetAllProducts()
        {
            return products;
        }
    }
}
