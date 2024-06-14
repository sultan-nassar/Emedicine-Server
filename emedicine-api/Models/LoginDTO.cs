using System.ComponentModel.DataAnnotations;

namespace emedicine_api.Models
{
    public class LoginDTO
    {
        [Required]
        [MinLength(6)]
        [MaxLength(255)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
