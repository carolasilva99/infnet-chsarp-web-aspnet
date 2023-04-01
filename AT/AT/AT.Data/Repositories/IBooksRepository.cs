using AT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Data.Repositories
{
    public interface IBooksRepository
    {
        Task<IEnumerable<Book>> GetAsync();
        Task<Book> GetAsync(int id);
        Task<Book> CreateAsync(Book book);
        Task<Book> UpdateAsync(Book book);
        Task<Book> DeleteAsync(Book book);
        Task<Book> AddAuthor(Book book);
        Task<Book> RemoveAuthor(Book book);
    }
}
