using System.ComponentModel.DataAnnotations;

namespace DatingApp2.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        [MinLength(2, 
            ErrorMessage = "Your Username must contain at least two characters.")]
        public string UserName { get; set; }
        [Required]
        [MinLength(6, 
            ErrorMessage = "Your password must be at least 6 characters long.")]
        public string Password { get; set; }
    }
}