using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AT.Data.Context;
using AT.Models;
using Microsoft.EntityFrameworkCore;

namespace AT.Services
{
    public class BooksService : IBooksService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IAuthorsService _authorsService;

        public BooksService(DatabaseContext databaseContext, IAuthorsService authorsService)
        {
            _databaseContext = databaseContext;
            _authorsService = authorsService;
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
            var authors = await GetAuthorsFromId(book);

            book.Authors = authors;

            _databaseContext.Books.Add(book);
            
            await _databaseContext.SaveChangesAsync();

            return book;
        }

        private async Task<List<Author>> GetAuthorsFromId(Book book)
        {
            var authors = new List<Author>();

            foreach (var newAuthor in book.Authors)
            {
                var author = await _authorsService.GetAsync(newAuthor.Id);

                if (author != null)
                {
                    authors.Add(author);
                }
            }

            return authors;
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            var authors = await GetAuthorsFromId(book);

            book.Authors = authors;

            _databaseContext.Entry(book).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();
            return book;
        }

        public async Task<Book> DeleteAsync(int id)
        {
            var book = await GetAsync(id);

            _databaseContext.Books.Remove(book);
            await _databaseContext.SaveChangesAsync();

            return book;
        }
    }
}
