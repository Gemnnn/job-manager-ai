using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class JobDescriptionRaw
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

        public Job? Job { get; set; }
    }

}
