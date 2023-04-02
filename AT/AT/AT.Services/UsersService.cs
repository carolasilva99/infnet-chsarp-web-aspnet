using AT.Data.Repositories;
using AT.Models;
using Microsoft.AspNetCore.Identity;

namespace AT.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<IdentityResult> CreateUserAsync(User user, string password)
        {
            return await _usersRepository.CreateUserAsync(user, password);
        }

        public async Task<bool> ValidateUserAsync(UserLogin loginDto)
        {
            throw new NotImplementedException();
        }

        public async Task<Token> CreateTokenAsync(UserLogin user)
        {
            if (!await _usersRepository.ValidateUserAsync(user))
                return null;

            var userModel = await _usersRepository.GetUserAsync(user);

            return await _usersRepository.CreateTokenAsync(userModel);
        }

        public async Task<Token> CreateTokenAsync(UserEmailLogin user)
        {
            if (!await _usersRepository.ValidateUserAsync(user))
                return null;

            var userModel = await _usersRepository.GetUserAsync(user);

            return await _usersRepository.CreateTokenAsync(userModel);
        }
    }
}
