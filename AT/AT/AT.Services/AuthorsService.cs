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
    public class AuthorsService : IAuthorsService
    {
        private readonly DatabaseContext _databaseContext;

        public AuthorsService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Author>> GetAsync()
        {
            var authors = await _databaseContext
                .Authors
                .Include(b => b.Books)
                .ToListAsync();

            return authors;
        }

        public async Task<Author> GetAsync(int id)
        {
            var author = _databaseContext
                .Authors
                .Where(a => a.Id == id)
                .Include(b => b.Books)
                .FirstOrDefault();


            return author;
        }

        public async Task<Author> CreateAsync(Author author)
        {
            _databaseContext.Authors.Add(author);
            await _databaseContext.SaveChangesAsync();

            return author;
        }

        public async Task<Author> UpdateAsync(Author author)
        {
            _databaseContext.Entry(author).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();
            return author;
        }

        public async Task<Author> DeleteAsync(int id)
        {
            var author = await GetAsync(id);

            _databaseContext.Authors.Remove(author);
            await _databaseContext.SaveChangesAsync();

            return author;
        }
    }
}
