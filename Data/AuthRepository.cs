using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using DatingApp2.API.Models;
using Microsoft.EntityFrameworkCore;

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
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<User> Login(string username, string password)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null)
                return null;

            return !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt) ? null : user;
        }

        private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                byte[] computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                if (computeHash.Where((t, i) => t != passwordHash[i]).Any())
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<bool> UserExists(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}