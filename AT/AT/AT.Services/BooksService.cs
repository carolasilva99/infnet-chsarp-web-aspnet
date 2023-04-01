using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AT.Data.Context;
using AT.Data.Repositories;
using AT.Models;
using Microsoft.EntityFrameworkCore;

namespace AT.Services
{
    public class BooksService : IBooksService
    {
        private readonly IAuthorsService _authorsService;
        private readonly IBooksRepository _booksRepository;

        public BooksService(IAuthorsService authorsService, IBooksRepository booksRepository)
        {
            _authorsService = authorsService;
            _booksRepository = booksRepository;
        }

        public async Task<IEnumerable<Book>> GetAsync()
        {
            return await _booksRepository.GetAsync();
        }

        public async Task<Book> GetAsync(int id)
        {
            return await _booksRepository.GetAsync(id);
        }

        public async Task<Book> CreateAsync(Book book)
        {
            var authors = await GetAuthorsFromId(book);

            book.Authors = authors;

            return await _booksRepository.CreateAsync(book);
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
            return await _booksRepository.UpdateAsync(book);
        }

        public async Task<Book> DeleteAsync(int id)
        {
            var book = await GetAsync(id);
            return await _booksRepository.DeleteAsync(book);
        }

        public async Task<Book> AddAuthor(int bookId, int authorId)
        {
            var book = await GetAsync(bookId);
            var author = await _authorsService.GetAsync(authorId);

            book.Authors.Add(author);

            return await _booksRepository.AddAuthor(book);
        }

        public async Task<Book> RemoveAuthor(int bookId, int authorId)
        {
            var book = await GetAsync(bookId);
            var author = await _authorsService.GetAsync(authorId);

            book.Authors.Remove(author);

            return await _booksRepository.RemoveAuthor(book);
        }
    }
}
