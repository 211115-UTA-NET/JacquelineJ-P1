using Project1WebApp.Models;

namespace Project1WebApp.Repository
{
    public interface IStoreRepository
    {
        public void addNewStore(StoreModel store);
        public List<StoreModel> getAllStores();
        public StoreModel getStore(int storeId);
    }
}