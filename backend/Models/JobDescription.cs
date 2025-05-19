using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class JobDescription
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Job? Job { get; set; }
    }

}
