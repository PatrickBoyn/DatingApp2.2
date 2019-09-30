using System.Threading.Tasks;
using DatingApp2.API.Models;

namespace DatingApp2.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<User> Register(User user, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UserExists(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}