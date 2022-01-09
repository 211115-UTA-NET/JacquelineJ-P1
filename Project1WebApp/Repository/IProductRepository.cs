using Project1WebApp.Models;

namespace Project1WebApp.Repository
{
    public interface IProductRepository
    {
        public List<ProductModel> getProducts(int storeId);
        public List<ProductModel> addNewProduct(ProductModel product);
        public List<ProductModel> updateProductQuantity(int ProductId, int ProductQuantity);
    }
}