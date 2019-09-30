using System.Threading.Tasks;
using DatingApp2.API.Data;
using DatingApp2.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp2.API.Controllers
{
    [Route("ap/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            username = username.ToLower();

            if (await _repo.UserExists(username))
                return BadRequest("Username already exists");

            var userToCreate = new User
            {
                UserName = username
            };

            User createdUser = await _repo.Register(userToCreate, password);

            return StatusCode(201);
        }
    }
}