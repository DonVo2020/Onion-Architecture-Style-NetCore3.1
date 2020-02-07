using System.ComponentModel.DataAnnotations;

namespace OnionArch.AuthService
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public int Role { get; set; }
    }
}
