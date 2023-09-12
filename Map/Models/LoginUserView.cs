using System.ComponentModel.DataAnnotations;

namespace Map.Models
{
    public class LoginUserView
    {
        [Required]
        public string? Login { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
