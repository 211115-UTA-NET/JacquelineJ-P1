using Project1WebApp.Models;

namespace Project1WebApp.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooksAsync();
    }
}