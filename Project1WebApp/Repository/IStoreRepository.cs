using Project1WebApp.Models;

namespace Project1WebApp.Repository
{
    public interface IStoreRepository
    {
        public List<StoreModel> addNewStore(StoreModel store);
        public List<StoreModel> getStores(int storeId);
    }
}