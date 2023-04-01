using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            return await _usersRepository.CreateTokenAsync(user);
        }
    }
}
