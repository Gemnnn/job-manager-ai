using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; } = string.Empty;

        public string? GoogleId { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string Role { get; set; } = "User"; // "User", "Admin", "Pro"

        public ICollection<Job> Jobs { get; set; } = new List<Job>();
    }

}
