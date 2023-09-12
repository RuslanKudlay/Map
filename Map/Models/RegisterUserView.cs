using System.ComponentModel.DataAnnotations;

namespace Map.Models
{
    public class RegisterUserView
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? FatherName { get; set; }

        [Required]
        public string? Position { get; set; }

        [Required]
        public string? Login { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
