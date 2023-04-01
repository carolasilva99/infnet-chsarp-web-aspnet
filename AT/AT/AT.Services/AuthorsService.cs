using AT.Data.Repositories;
using AT.Models;

namespace AT.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly IAuthorsRepository _authorsRepository;

        public AuthorsService(IAuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        public async Task<IEnumerable<Author>> GetAsync()
        {
            return await _authorsRepository.GetAsync();
        }

        public async Task<Author> GetAsync(int id)
        {
            return await _authorsRepository.GetAsync(id);
        }

        public async Task<Author> CreateAsync(Author author)
        {
            return await _authorsRepository.CreateAsync(author);
        }

        public async Task<Author> UpdateAsync(Author author)
        {
            return await _authorsRepository.UpdateAsync(author);
        }

        public async Task<Author> DeleteAsync(int id)
        {
            var author = await GetAsync(id);

            return await _authorsRepository.DeleteAsync(author);
        }
    }
}
