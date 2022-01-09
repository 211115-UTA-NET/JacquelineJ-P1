using Microsoft.EntityFrameworkCore;
using Project1WebApp.Data;
using Project1WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1WebApp.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly StoreContext _context;
        public BookRepository(StoreContext context)
        {
            _context = context;
        }   

        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var records = await _context.Books.Select(x => new BookModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
            }).ToListAsync();
            
            return records;
        }
    }
}
