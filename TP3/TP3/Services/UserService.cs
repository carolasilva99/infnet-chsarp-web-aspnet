using TP3.Data;
using TP3.Models;

namespace TP3.Services
{
    public interface IUserService
    {
        User GetByUsername(string username);
    }

    public class UserService : IUserService
    {
        private readonly TP3Context _context;

        public UserService(TP3Context context)
        {
            _context = context;
        }

        public User GetByUsername(string username)
        {
            return _context.User?.FirstOrDefault(u => u.Username == username);
        }
    }
}
