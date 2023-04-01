using AT.Models;

namespace AT.Data.Repositories
{
    public interface IAuthorsRepository
    {
        Task<IEnumerable<Author>> GetAsync();
        Task<Author> GetAsync(int id);
        Task<Author> CreateAsync(Author author);
        Task<Author> UpdateAsync(Author author);
        Task<Author> DeleteAsync(Author author);
    }
}
