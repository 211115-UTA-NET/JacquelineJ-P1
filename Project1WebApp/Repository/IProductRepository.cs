using Project1WebApp.Models;

namespace Project1WebApp.Repository
{
    public interface IProductRepository
    {
        public List<ProductModel> getProducts(int storeId);
        public void addNewProduct(ProductModel product);
        public void updateProductQuantity(int ProductId, int ProductQuantity);
    }
}