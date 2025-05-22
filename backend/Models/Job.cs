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
        public string? ContractDuration { get; set; }
        public DateTime? PostedAt { get; set; }
        public string? ApplicationUrl { get; set; }
        public string? Source { get; set; }
        public string? RecruiterName { get; set; }
        public string? Notes { get; set; }

        public int? IndustryId { get; set; }
        public Industry? Industry { get; set; }

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        public JobStatus? Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastUpdatedAt { get; set; }

        public int? JobDescriptionId { get; set; }
        public JobDescription? JobDescription { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public ICollection<RequiredSkill> JobSkills { get; set; } = new List<RequiredSkill>();
        public ICollection<JobBenefit> JobBenefits { get; set; } = new List<JobBenefit>();
    }


}
