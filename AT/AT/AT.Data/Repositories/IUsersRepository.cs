using AT.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Data.Repositories
{
    public interface IUsersRepository
    {
        Task<IdentityResult> CreateUserAsync(User user, string password);
        Task<bool> ValidateUserAsync(UserLogin loginDto);
        Task<Token> CreateTokenAsync(UserLogin user);
    }
}
