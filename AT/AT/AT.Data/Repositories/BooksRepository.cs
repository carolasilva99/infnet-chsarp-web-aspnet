using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AT.Data.Context;
using AT.Models;
using Microsoft.EntityFrameworkCore;

namespace AT.Data.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly DatabaseContext _databaseContext;

        public BooksRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Book>> GetAsync()
        {
            var books = await _databaseContext
                .Books
                .Include(b => b.Authors)
                .ToListAsync();

            return books;
        }

        public async Task<Book> GetAsync(int id)
        {
            var book = _databaseContext
                .Books
                .Where(a => a.Id == id)
                .Include(b => b.Authors)
                .FirstOrDefault();

            return book;
        }

        public async Task<Book> CreateAsync(Book book)
        {
            _databaseContext.Books.Add(book);
            await _databaseContext.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            _databaseContext.Entry(book).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();
            return book;
        }

        public async Task<Book> DeleteAsync(Book book)
        {
            _databaseContext.Books.Remove(book);
            await _databaseContext.SaveChangesAsync();
            return book;
        }

        public async Task<Book> AddAuthor(Book book)
        {
            await _databaseContext.SaveChangesAsync();
            return book;
        }

        public async Task<Book> RemoveAuthor(Book book)
        {
            await _databaseContext.SaveChangesAsync();
            return book;
        }
    }
}
