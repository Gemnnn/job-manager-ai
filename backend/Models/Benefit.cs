using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Benefit
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<JobBenefit> JobBenefits { get; set; } = new List<JobBenefit>();
    }
}
