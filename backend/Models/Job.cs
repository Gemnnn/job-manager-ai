using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Job
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Company { get; set; }

        public EmploymentType? EmploymentType { get; set; }

        public WorkArrangementType? WorkArrangement { get; set; }

        public int? LocationId { get; set; }
        public Location? Location { get; set; }

        public decimal? Salary { get; set; }

        public string? Notes { get; set; }

        public JobStatus? Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? AppliedAt { get; set; }
        public DateTime? LastStatusUpdate { get; set; }

        public int? RawDescriptionId { get; set; }
        public JobDescriptionRaw? RawDescription { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }

}
