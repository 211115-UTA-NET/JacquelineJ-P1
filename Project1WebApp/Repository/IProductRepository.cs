using Project1WebApp.Models;

namespace Project1WebApp.Repository
{
    public interface IProductRepository
    {
        int AddProduct(ProductModel product);
        List<ProductModel> GetAllProducts();
    }
}