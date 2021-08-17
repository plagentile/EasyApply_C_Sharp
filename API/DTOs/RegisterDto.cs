using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {

        [Required]
        [StringLength(32, MinimumLength =8)]
        public string Username { get; set; }

        [Required]
        [StringLength(32, MinimumLength =8)]
        public string Password { get; set; }
    }
}