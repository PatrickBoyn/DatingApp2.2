using System.Threading.Tasks;
using DatingApp2.API.Data;
using DatingApp2.API.Dtos;
using DatingApp2.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto user)
        {
            user.UserName = user.UserName.ToLower();

            if (await _repo.UserExists(user.UserName))
                return BadRequest($"The name {user.UserName} already exists.");
            // The reason this is var and not User is, it's more obvious here.
            var userToCreate = new User
            {
                UserName = user.UserName
            };
            
            // It's not as obvious that this is a User.
            User createdUser = await _repo.Register(userToCreate, user.Password);

            return StatusCode(201);
        }
    }
}