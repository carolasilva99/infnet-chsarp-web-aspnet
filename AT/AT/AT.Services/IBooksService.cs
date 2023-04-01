using AT.Models;

namespace AT.Services
{
    public interface IBooksService
    {
        Task<IEnumerable<Book>> GetAsync();
        Task<Book> GetAsync(int id);
        Task<Book> CreateAsync(Book author);
        Task<Book> UpdateAsync(Book author);
        Task<Book> DeleteAsync(int id);
        Task<Book> AddAuthor(int bookId, int authorId);
        Task<Book> RemoveAuthor(int bookId, int authorId);
    }
}