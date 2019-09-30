using DatingApp2.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp2.API.Controllers
{
    [Route("ap/[controller]")]
    [ApiController]
    public class AuthController 
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }
    }
}