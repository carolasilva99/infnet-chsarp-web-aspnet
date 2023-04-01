using AT.Models;

namespace AT.Services
{
    public interface IAuthorsService
    {
        Task<IEnumerable<Author>> GetAsync();
        Task<Author> GetAsync(int id);
        Task<Author> CreateAsync(Author author);
        Task<Author> UpdateAsync(Author author);
        Task<Author> DeleteAsync(int id);
    }
}